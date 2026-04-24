using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class AdminReportController : Controller
    {
        private readonly AppDbContext _context;
        public AdminReportController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int days = 30)
        {
            var fromDate = DateTime.Now.AddDays(-days);

            var rentals = _context.Rentals
                .Where(r => r.EndTime != null && r.EndTime >= fromDate)
                .Include(r => r.Vehicle)
                .Include(r => r.PickupStation)
                .ToList();

            var bikeRevenue = rentals
                .Where(r => r.Vehicle.VehicleType == "Bike")
                .Sum(r => r.FinalAmount);

            var scooterRevenue = rentals
                .Where(r => r.Vehicle.VehicleType == "E-Scooter")
                .Sum(r => r.FinalAmount);

            var stationRevenue = rentals
                .GroupBy(r => r.PickupStation.Name)
                .Select(g => new StationRevenueVM
                {
                    StationName = g.Key,
                    BikeRevenue = g.Where(x => x.Vehicle.VehicleType == "Bike").Sum(x => x.FinalAmount),
                    ScooterRevenue = g.Where(x => x.Vehicle.VehicleType == "E-Scooter").Sum(x => x.FinalAmount),
                    Total = g.Sum(x => x.FinalAmount)
                }).ToList();

            var stationStatus = _context.Stations
                .Select(s => new StationStatusVM
                {
                    StationName = s.Name,
                    Capacity = s.Capacity,
                    Current = s.CurrentInventory,
                    Status = s.CurrentInventory < (s.Capacity * 0.2) ? "Low" : "Normal"
                }).ToList();

            var vm = new ReportViewModel
            {
                BikeRevenue = bikeRevenue,
                ScooterRevenue = scooterRevenue,
                TotalRevenue = bikeRevenue + scooterRevenue,
                StationRevenues = stationRevenue,
                StationStatuses = stationStatus
            };

            return View(vm);
        }

        public IActionResult Export()
        {
            var data = _context.Rentals.ToList();

            var csv = "Id,Amount\n";

            foreach (var r in data)
            {
                csv += $"{r.Id},{r.FinalAmount}\n";
            }

            return File(System.Text.Encoding.UTF8.GetBytes(csv),
                "text/csv",
                "report.csv");
        }
    }
}
