using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;

namespace SaigonRideProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var stations = _context.Stations
                .Include(s => s.Vehicles)
                .ToList();

            return View(stations);
        }

        public IActionResult UserDashboard()
        {
            var stations = _context.Stations
                .Include(s => s.Vehicles)
                .ToList();

            return View(stations);
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