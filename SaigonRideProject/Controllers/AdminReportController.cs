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
                    Current = s.Vehicles.Count(),
                    Status = s.Vehicles.Count() < (s.Capacity * 0.2) ? "Low" : "Normal"
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

        public IActionResult ExportRevenue(int days = 30)
        {
            var fromDate = DateTime.Now.AddDays(-days);

            var data = _context.Rentals
                .Where(r => r.EndTime != null && r.EndTime >= fromDate)
                .Include(r => r.Vehicle)
                .Include(r => r.PickupStation)
                .ToList();

            var csv = "Station,Bike Revenue,Scooter Revenue,Total\n";

            var grouped = data
                .GroupBy(r => r.PickupStation.Name)
                .Select(g => new
                {
                    Station = g.Key,
                    Bike = g.Where(x => x.Vehicle.VehicleType == "Bike").Sum(x => x.FinalAmount),
                    Scooter = g.Where(x => x.Vehicle.VehicleType == "E-Scooter").Sum(x => x.FinalAmount),
                    Total = g.Sum(x => x.FinalAmount)
                });

            foreach (var item in grouped)
            {
                csv += $"{item.Station},{item.Bike},{item.Scooter},{item.Total}\n";
            }

            return File(System.Text.Encoding.UTF8.GetBytes(csv),
                "text/csv",
                $"Revenue_Report_{days}days.csv");
        }

        public IActionResult ExportInventory()
        {
            var stations = _context.Stations
                .Include(s => s.Vehicles)
                .ToList();

            var csv = "Station,Capacity,Current,Status\n";

            foreach (var s in stations)
            {
                var current = s.Vehicles.Count();
                var status = GetStatus(s.Capacity, current);

                csv += $"{s.Name},{s.Capacity},{current},{status}\n";
            }

            return File(
                System.Text.Encoding.UTF8.GetBytes(csv),
                "text/csv",
                "Inventory_Report.csv"
            );
        }

        private string GetStatus(int capacity, int current)
        {
            if (capacity == 0) return "Low";

            double ratio = (double)current / capacity;

            if (ratio < 0.2) return "Low";
            if (ratio < 0.7) return "Normal";
            return "Full";
        }
    }
}
