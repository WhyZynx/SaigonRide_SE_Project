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
                return RedirectToAction("Login", "Account");

            return RedirectToAction("UserDashboard");
        }

        

        public IActionResult Dashboard()
        {
            ViewBag.TotalUsers = _context.Users.Count();
            ViewBag.TotalVehicles = _context.Vehicles.Count();
            ViewBag.TotalStations = _context.Stations.Count();
            ViewBag.ActiveRentals = _context.Rentals.Count(r => r.Status == "InProgress");

            ViewBag.TotalRevenue = _context.Rentals
                .Where(r => r.Status == "Completed")
                .Sum(r => r.FinalAmount);

            return View();
        }
    }
}