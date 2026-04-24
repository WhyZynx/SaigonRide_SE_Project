using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;

namespace SaigonRideProject.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RevenueReport()
        {
            var report = _context.Rentals
                .Where(r => r.Status == "Completed")
                .GroupBy(r => r.Vehicle.VehicleType)
                .Select(g => new
                {
                    VehicleType = g.Key,
                    TotalRevenue = g.Sum(x => x.FinalAmount)
                }).ToList();

            return View(report);
        }

        public IActionResult StationReport()
        {
            var report = _context.Stations
                .Select(s => new
                {
                    s.Name,
                    s.Capacity,
                    s.CurrentInventory,
                    Utilization = (double)s.CurrentInventory / s.Capacity * 100
                }).ToList();

            return View(report);
        }
    }
}
