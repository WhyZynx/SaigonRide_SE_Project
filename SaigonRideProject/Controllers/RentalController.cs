using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Payment;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class RentalController : Controller
    {
        private readonly RentalService _rentalService;
        private readonly WalletService _walletService;
        private readonly AppDbContext _context;

        public RentalController(
            RentalService rentalService,
            WalletService walletService,
            AppDbContext context)
        {
            _rentalService = rentalService;
            _walletService = walletService;
            _context = context;
        }

        public IActionResult StationList()
        {
            var stations = _context.Stations
                .Select(s => new StationMapViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    AvailableCount = s.Vehicles.Count(v => v.Status == "Available"),
                    Capacity = s.Capacity
                })
                .ToList();

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
                    Longitude = station.Longitude
                },
                Vehicles = vehicles,
                AvailableCount = vehicles.Count(v => v.Status == "Available"),
                Capacity = station.Capacity,
                CurrentInventory = station.CurrentInventory
            };

            return View(model);
        }

        public IActionResult Start(int vehicleId, int stationId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.Find(userId);

            if (user == null || user.IsLocked)
                return BadRequest("Account locked");

            _rentalService.ValidateCanRent(userId.Value);

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
            var station = _context.Stations.FirstOrDefault(s => s.Id == stationId);

            if (vehicle == null || station == null)
                return BadRequest("Invalid data");

            if (vehicle.Status != "Available")
                return BadRequest("Vehicle not available");

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var rental = _rentalService.StartRental(userId.Value, vehicleId, stationId);

                vehicle.Status = "InUse";

                station.CurrentInventory = Math.Max(0, station.CurrentInventory - 1);

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

        public IActionResult Current(int id)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == id);

            if (rental == null || rental.Vehicle == null)
                return NotFound();

            var pickup = _context.Stations
                .FirstOrDefault(s => s.Id == rental.PickupStationId);

            var model = new CurrentTripViewModel
            {
                Id = rental.Id,
                StartTime = rental.StartTime,
                VehicleName = rental.Vehicle.VehicleType,
                PricePerMinute = rental.Vehicle.PricePerMinute,
                PickupLat = pickup.Latitude,
                PickupLng = pickup.Longitude
            };

            ViewBag.Stations = _context.Stations
                .Select(s => new
                {
                    id = s.Id,
                    name = s.Name,
                    latitude = s.Latitude,
                    longitude = s.Longitude,
                    capacity = s.Capacity,
                    currentCount = s.CurrentInventory
                })
                .ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult ConfirmPayment(int rentalId, int returnStationId, string paymentMethod)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == rentalId);

            if (rental == null) return NotFound();

            var user = _context.Users.Find(rental.UserId);
            var station = _context.Stations.Find(returnStationId);

            if (user == null || station == null)
                return BadRequest("Invalid data");

            var minutes = (DateTime.Now - rental.StartTime).TotalMinutes;

            var baseAmount = (decimal)minutes * rental.Vehicle.PricePerMinute;

            var discount = station.CurrentInventory < (station.Capacity * 0.2m)
                ? 0.15m
                : 0m;

            var finalAmount = baseAmount * (1 - discount);

            if (!_walletService.CanPay(user, finalAmount))
                return RedirectToAction("TopUp", "User");

            var strategy = PaymentFactory.GetStrategy(user.UserType, paymentMethod);

            _walletService.Pay(user, finalAmount, paymentMethod);

            rental.EndTime = DateTime.Now;
            rental.Status = "Completed";
            rental.BaseAmount = baseAmount;
            rental.DiscountPercent = discount;
            rental.FinalAmount = finalAmount;
            rental.PaymentMethod = paymentMethod;

            rental.Vehicle.Status = "Available";
            rental.Vehicle.StationId = returnStationId;

            station.CurrentInventory += 1;

            _context.SaveChanges();

            return RedirectToAction("PaymentSuccess", new { amount = finalAmount });
        }

        public IActionResult PaymentSuccess(decimal amount)
        {
            ViewBag.Amount = amount;
            return View();
        }

        public IActionResult History()
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (userId == 0)
                return RedirectToAction("Index", "Home");

            var rentals = _context.Rentals
                .Include(r => r.Vehicle)
                .Where(r => r.UserId == userId && r.Status == "Completed")
                .OrderByDescending(r => r.EndTime)
                .ToList();

            return View(rentals);
        }
    }
}