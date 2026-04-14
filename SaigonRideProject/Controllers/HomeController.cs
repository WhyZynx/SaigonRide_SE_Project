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
            return View();
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}