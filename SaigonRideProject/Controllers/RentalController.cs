using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Payment;
using SaigonRideProject.Services.Pricing;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class RentalController : BaseController
    {
        private readonly RentalService _rentalService;
        private readonly WalletService _walletService;
        private readonly AppDbContext _context;
        private readonly StationService _stationService;
        private readonly IPricingStrategy pricing;

        public RentalController(
            RentalService rentalService,
            WalletService walletService,
            StationService stationService,
            AppDbContext context,
            IPricingStrategy pricing) : base(context)
        {
            _rentalService = rentalService;
            _walletService = walletService;
            _context = context;
            _stationService = stationService;
            this.pricing = pricing;
        }

        public IActionResult StationList()
        {
            var stationsData = _context.Stations
             .AsNoTracking()
             .ToList();

            var stations = stationsData.Select(s => new StationMapViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Capacity = s.Capacity,

                VehicleCount = _context.Vehicles.Count(v => v.StationId == s.Id),
                AvailableCount = _context.Vehicles.Count(v => v.StationId == s.Id && v.Status == "Available"),

                FillPercent = _stationService.GetFillPercent(s),
                IsLowCapacity = _stationService.IsLowCapacity(s)
            }).ToList();

            return View(stations);
        }

        public IActionResult StationDetail(int id)
        {
            var station = _context.Stations
                .Include(s => s.Vehicles)
                .FirstOrDefault(s => s.Id == id);

            if (station == null) return NotFound();

            var vehicles = station.Vehicles
                .Select(v => new VehicleViewModel
                {
                    Id = v.Id,
                    VehicleType = v.VehicleType,
                    PlateNumber = v.PlateNumber,
                    BatteryLevel = v.BatteryLevel,
                    PricePerMinute = v.PricePerMinute,
                    Status = v.Status
                })
                .ToList();

            var model = new StationDetailViewModel
            {
                Station = new StationMapViewModel
                {
                    Id = station.Id,
                    Name = station.Name,
                    Address = station.Address,
                    Latitude = station.Latitude,
                    Longitude = station.Longitude,
                    VehicleCount = station.Vehicles.Count()
                },
                Vehicles = vehicles,
                AvailableCount = vehicles.Count(v => v.Status == "Available"),
                Capacity = station.Capacity,
                VehicleCount = station.Vehicles.Count(),
            };

            return View(model);
        }

        public IActionResult Start(int vehicleId, int stationId)
        {

            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var activeRental = _context.Rentals
                .FirstOrDefault(r =>
                    r.UserId == userId.Value &&
                    r.Status == "InProgress" &&
                    r.EndTime == null
                );

            if (activeRental != null)
            {
                return RedirectToAction("Current", new { id = activeRental.Id });
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null || user.IsLocked)
                return BadRequest("Account locked");

            _rentalService.ValidateCanRent(userId.Value);

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
            var station = _context.Stations.FirstOrDefault(s => s.Id == stationId);

            if (vehicle == null || station == null)
                return BadRequest("Invalid data");


            if (vehicle.BatteryLevel < 20)
                return BadRequest("Battery too low to rent");

            if (vehicle.Status != "Available")
                return BadRequest("Vehicle not available");

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var rental = _rentalService.StartRental(userId.Value, vehicleId, stationId);

                vehicle.Status = "InUse";
                vehicle.StationId = null;

                _context.SaveChanges();

                transaction.Commit();

                return RedirectToAction("Current", new { id = rental.Id });
            }
            catch
            {
                transaction.Rollback();
                return BadRequest("Failed to start rental");
            }
        }

        [HttpGet]
        public IActionResult GetActiveRental()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return Json(null);

            var rental = _context.Rentals
            .Where(r => r.UserId == userId && r.Status == "InProgress")
            .Select(r => new
            {
                r.Id,
                r.StartTime,
                PricePerMinute = r.Vehicle.PricePerMinute
            })
            .FirstOrDefault();

            return Json(rental);
        }

        public IActionResult Current(int id)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == id);

            if (rental == null || rental.Vehicle == null)
                return NotFound();

            var pickup = _context.Stations
                .FirstOrDefault(s => s.Id == rental.PickupStationId);

            if (pickup == null)
                return NotFound();

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(x => x.Id == userId.Value);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var model = new CurrentTripViewModel
            {
                Id = rental.Id,
                StartTime = rental.StartTime,
                VehicleName = rental.Vehicle.VehicleType,
                PricePerMinute = rental.Vehicle.PricePerMinute,
                PickupLat = pickup.Latitude,
                PickupLng = pickup.Longitude
            };

            ViewBag.PaymentMethods = PaymentMethodProvider.Get(user.UserType) ?? new[] { "Cash" };
                foreach (var s in _context.Stations.Include(x => x.Vehicles))
                {
                    Console.WriteLine($"{s.Name}: {s.Vehicles.Count}");
                }
            var stations = _context.Stations
    .AsNoTracking()
    .Select(s => new
    {
        s.Id,
        s.Name,
        s.Latitude,
        s.Longitude,
        s.Capacity,

        vehicleCount = _context.Vehicles.Count(v => v.StationId == s.Id),
        availableCount = _context.Vehicles.Count(v => v.StationId == s.Id && v.Status == "Available")
    })
    .ToList();

            ViewBag.Stations = stations.Select(s => new
            {
                id = s.Id,
                name = s.Name,
                latitude = s.Latitude,
                longitude = s.Longitude,
                capacity = s.Capacity,
                vehicleCount = s.vehicleCount,
                availableCount = s.availableCount,

                fillPercent = s.Capacity == 0 ? 0 : (double)s.vehicleCount / s.Capacity,
                isLow = s.Capacity > 0 && ((double)s.vehicleCount / s.Capacity) < 0.2
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult EndTrip(int rentalId, int returnStationId)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == rentalId);

            if (rental == null) return NotFound();

            var user = _context.Users.Find(rental.UserId);
            var station = _context.Stations.Find(returnStationId);

            var duration = DateTime.Now - rental.StartTime;

            var result = pricing.Calculate(
                rental.Vehicle,
                duration,
                station,
                user
            );

            rental.ReturnStationId = returnStationId;

            rental.BaseAmount = result.BaseAmount;
            rental.DiscountPercent = result.DiscountPercent;
            rental.FinalAmount = result.FinalAmount;

            _context.SaveChanges();

            return RedirectToAction("Bill", new { rentalId });
        }

        public IActionResult Bill(int rentalId)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == rentalId);

            if (rental == null) return NotFound();

            var userId = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.Find(userId);

            ViewBag.PaymentMethods = PaymentMethodProvider.Get(user.UserType);

            return View(rental);
        }


        [HttpPost]
        public IActionResult ConfirmPayment(int rentalId, string paymentMethod)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == rentalId);

            if (rental == null) return BadRequest();

            var payment = new Payment
            {
                RentalId = rentalId,
                Amount = rental.FinalAmount,
                Method = paymentMethod,
                Status = "Pending",
                QrCodeUrl = GenerateQr(rental.FinalAmount)
            };

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return Json(new
            {
                success = true,
                paymentId = payment.Id,
                qr = payment.QrCodeUrl,
                amount = rental.FinalAmount,
                baseAmount = rental.BaseAmount
            });
        }

        [HttpPost]
        public IActionResult CompletePayment(int id)
        {
            var payment = _context.Payments
                .FirstOrDefault(p => p.Id == id);

            if (payment == null)
                return Json(new { success = false });

            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == payment.RentalId);

            var user = _context.Users.Find(rental.UserId);
            var station = _context.Stations.Find(rental.ReturnStationId);

            if (station == null)
                return Json(new { success = false, message = "Station not found" });

            var vehicleCount = _context.Vehicles.Count(v => v.StationId == station.Id);

            if (vehicleCount >= station.Capacity)
                return Json(new { success = false, message = "Station is full" });

            if (!_walletService.CanPay(user, payment.Amount))
                return Json(new { success = false });

            _walletService.Pay(user, payment.Amount, payment.Method);

            payment.Status = "Completed";

            rental.Status = "Completed";
            rental.EndTime = DateTime.Now;
            rental.PaymentMethod = payment.Method;

            rental.Vehicle.Status = "Available";
            rental.Vehicle.StationId = station.Id;

            _context.SaveChanges();

            return Json(new
            {
                success = true,
                amount = payment.Amount,
                baseAmount = rental.BaseAmount
            });
        }

        private string GenerateQr(decimal amount)
        {
            return $"https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=PAY:{amount}";
        }

        public IActionResult PaymentSuccess(int paymentId)
        {
            var payment = _context.Payments
                .Include(p => p.Rental)
                .FirstOrDefault(p => p.Id == paymentId);

            if (payment == null)
                return NotFound();

            ViewBag.Amount = payment.Amount;
            ViewBag.Method = payment.Method;

            return View();
        }
        public IActionResult History()
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var rentals = _context.Rentals
                .Include(r => r.Vehicle)
                .Where(r => r.UserId == userId && r.Status == "Completed")
                .OrderByDescending(r => r.EndTime)
                .Select(r => new RentalHistoryViewModel
                {
                    VehicleType = r.Vehicle.VehicleType,
                    PlateNumber = r.Vehicle.PlateNumber,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,

                    BaseAmount = r.BaseAmount,
                    DiscountPercent = r.DiscountPercent,
                    FinalAmount = r.FinalAmount,

                    PaymentMethod = r.PaymentMethod
                })
                .ToList();

            return View(rentals);
        }
    }
}
