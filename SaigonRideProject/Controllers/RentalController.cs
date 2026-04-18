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
        private readonly AppDbContext _context;

        public RentalController(RentalService rentalService, AppDbContext context)
        {
            _rentalService = rentalService;
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
                    Longitude = s.Longitude
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
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (userId == 0)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.Find(userId);
            if (user == null)
                return NotFound();

            if (user.IsLocked)
                return BadRequest("Account is locked. Please top up.");

            if (user.Balance <= 0)
                return BadRequest("Insufficient balance.");

            var activeRental = _context.Rentals
                .FirstOrDefault(x => x.UserId == userId && x.Status == "InProgress");

            if (activeRental != null)
                return BadRequest("You already have an active rental.");

            var vehicle = _context.Vehicles
                .FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle == null)
                return BadRequest("Vehicle not found.");

            if (vehicle.Status != "Available")
                return BadRequest("Vehicle is not available.");

            if (vehicle.StationId != stationId)
                return BadRequest("Vehicle does not belong to this station.");

            var station = _context.Stations.Find(stationId);
            if (station == null)
                return BadRequest("Station not found.");

            if (station.CurrentInventory <= 0)
                return BadRequest("No vehicles available at this station.");

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var rental = _rentalService.StartRental(userId, vehicleId, stationId);

                    if (rental == null)
                        return BadRequest("Cannot start rental.");

                    vehicle.Status = "InUse";

                    station.CurrentInventory -= 1;

                    _context.SaveChanges();

                    transaction.Commit();

                    return RedirectToAction("Current", new { id = rental.Id });
                }
                catch
                {
                    transaction.Rollback();
                    return BadRequest("Error while starting rental.");
                }
            }
        }

        public IActionResult Current(int id)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == id);

            if (rental == null || rental.Vehicle == null)
                return NotFound();

            var pickup = _context.Stations.FirstOrDefault(s => s.Id == rental.PickupStationId);

            if (pickup == null)
                return NotFound();

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
                    capacity = s.Capacity,
                    currentCount = s.CurrentInventory,
                    latitude = s.Latitude,
                    longitude = s.Longitude
                })
                .ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult ConfirmPayment(int rentalId, int returnStationId, decimal amount, string paymentMethod)
        {
            var rental = _context.Rentals
                .Include(r => r.Vehicle)
                .FirstOrDefault(x => x.Id == rentalId);

            if (rental == null)
                return NotFound();

            var user = _context.Users.Find(rental.UserId);

            if (user == null)
                return NotFound();

            if (user.IsLocked)
                return BadRequest("Account is locked.");

            var station = _context.Stations.FirstOrDefault(s => s.Id == returnStationId);

            if (station == null)
                return NotFound();

            var duration = (DateTime.Now - rental.StartTime).TotalMinutes;
            var baseAmount = (decimal)duration * rental.Vehicle.PricePerMinute;

            decimal discount = (station.CurrentInventory * 1.0m / station.Capacity) < 0.2m ? 0.15m : 0m;
            var finalAmount = baseAmount * (1 - discount);

            if (user.Balance < finalAmount)
                return BadRequest("Not enough balance to complete payment.");

            var strategy = PaymentFactory.GetStrategy(paymentMethod);
            var message = strategy.Pay(finalAmount);

            user.Balance -= finalAmount;

            if (user.Balance < 0)
                user.IsLocked = true;

            rental.EndTime = DateTime.Now;
            rental.ReturnStationId = returnStationId;

            rental.BaseAmount = baseAmount;
            rental.DiscountPercent = discount;
            rental.FinalAmount = finalAmount;

            rental.PaymentMethod = paymentMethod;
            rental.Status = "Completed";

            rental.Vehicle.Status = "Available";
            rental.Vehicle.StationId = returnStationId;

            station.CurrentInventory += 1;

            _context.SaveChanges();

            TempData["PaymentMessage"] = message;

            return RedirectToAction("PaymentSuccess", new { amount = finalAmount });
        }

        public IActionResult PaymentSuccess(decimal amount)
        {
            ViewBag.Amount = amount;
            return View();
        }

        public IActionResult History()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (userId == 0)
                return RedirectToAction("UserDashboard", "Home");

            var rentals = _context.Rentals
                .Include(r => r.Vehicle)
                .Where(r => r.UserId == userId && r.Status == "Completed")
                .OrderByDescending(r => r.EndTime)
                .ToList();

            return View(rentals);
        }
    }
}