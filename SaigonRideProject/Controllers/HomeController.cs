using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Services;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RentalService _rentalService;

        public HomeController(AppDbContext context, RentalService rentalService)
        {
            _context = context;
            _rentalService = rentalService;
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return View("Index"); 

            return RedirectToAction("Login", "Account");
        }

        public IActionResult UserDashboard()
        {

            
            var userId = HttpContext.Session.GetInt32("UserId");
            var hasTrip = _rentalService.HasActiveRental(userId.Value);


            var user = _context.Users.Find(userId);

            var stations = _context.Stations.ToList();

            var model = new UserDashboardViewModel
            {
                User = user,
                Stations = stations.Select(s => new StationMapViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    AvailableCount = s.CurrentInventory
                }).ToList()
            };

            return View(model);
        }

        public IActionResult AdminDashboard()
        {
            var totalStations = _context.Stations.Count();
            var totalVehicles = _context.Vehicles.Count();
            var activeRentals = _context.Rentals.Count(r => r.EndTime == null);

            ViewBag.TotalStations = totalStations;
            ViewBag.TotalVehicles = totalVehicles;
            ViewBag.ActiveRentals = activeRentals;

            return View();
        }
    }
}