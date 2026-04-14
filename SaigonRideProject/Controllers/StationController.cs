using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;

namespace SaigonRideProject.Controllers
{
    public class StationController : Controller
    {
        private readonly AppDbContext _context;

        public StationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var stations = _context.Stations.ToList();
            return View(stations);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}