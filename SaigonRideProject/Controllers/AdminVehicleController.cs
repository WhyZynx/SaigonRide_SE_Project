using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.ViewModels;
using SaigonRideProject.Services;

namespace SaigonRideProject.Controllers
{
    public class AdminVehicleController : Controller
    {
        private readonly AppDbContext _context;

        public AdminVehicleController(AppDbContext context)
        {
            _context = context;
        }

        public static void NotifyChanged()
        {
            DashboardUpdateService.NotifyVehicle();
        }

        [HttpGet]
        public IActionResult CheckUpdate()
        {
            return Json(new { lastUpdated = DashboardUpdateService.GetVehicleUpdated() });
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        public IActionResult Index(string search, string vehicleType, string status)
        {
            var data = _context.Vehicles.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                data = data.Where(x => x.PlateNumber.Contains(search));

            if (!string.IsNullOrEmpty(vehicleType))
                data = data.Where(x => x.VehicleType == vehicleType);

            if (!string.IsNullOrEmpty(status))
                data = data.Where(x => x.Status == status);

            var result = data.Select(v => new AdminVehicleViewModel
            {
                Id = v.Id,
                VehicleType = v.VehicleType,
                PlateNumber = v.PlateNumber,
                Status = v.Status,
                PricePerMinute = v.PricePerMinute,
                BatteryLevel = v.BatteryLevel,
                StationId = v.StationId,
                StationName = v.Station != null ? v.Station.Name : "N/A"
            }).ToList();

            return View(result);
        }

        public IActionResult Create()
        {
            ViewBag.Stations = _context.Stations
                .Select(s => new { s.Id, s.Name })
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminVehicleViewModel model)
        {
            var vehicle = new Vehicle
            {
                VehicleType = model.VehicleType,
                PlateNumber = model.PlateNumber,
                Status = model.Status,
                PricePerMinute = model.PricePerMinute,
                BatteryLevel = model.BatteryLevel,
                StationId = model.StationId
            };

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            AdminVehicleController.NotifyChanged();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var vehicle = _context.Vehicles
                .Where(v => v.Id == id)
                .Select(v => new AdminVehicleViewModel
                {
                    Id = v.Id,
                    VehicleType = v.VehicleType,
                    PlateNumber = v.PlateNumber,
                    Status = v.Status,
                    PricePerMinute = v.PricePerMinute,
                    StationId = v.StationId,
                    BatteryLevel = v.BatteryLevel
                })
                .FirstOrDefault();

            if (vehicle == null) return NotFound();

            ViewBag.Stations = _context.Stations
                .Select(s => new { s.Id, s.Name })
                .ToList();

            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Edit(AdminVehicleViewModel model)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var vehicle = _context.Vehicles.Find(model.Id);

            if (vehicle == null) return NotFound();

            vehicle.VehicleType = model.VehicleType;
            vehicle.PlateNumber = model.PlateNumber;
            vehicle.Status = model.Status;
            vehicle.PricePerMinute = model.PricePerMinute;
            vehicle.StationId = model.StationId;

            _context.SaveChanges();
            AdminVehicleController.NotifyChanged();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var vehicle = _context.Vehicles
                .Where(v => v.Id == id)
                .Select(v => new AdminVehicleViewModel
                {
                    Id = v.Id,
                    VehicleType = v.VehicleType,
                    PlateNumber = v.PlateNumber,
                    Status = v.Status
                })
                .FirstOrDefault();

            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Delete(AdminVehicleViewModel model)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var vehicle = _context.Vehicles.Find(model.Id);

            if (vehicle == null) return NotFound();

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            AdminVehicleController.NotifyChanged();

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var vehicle = _context.Vehicles
                .Include(v => v.Station)
                .Where(v => v.Id == id)
                .Select(v => new AdminVehicleViewModel
                {
                    Id = v.Id,
                    VehicleType = v.VehicleType,
                    PlateNumber = v.PlateNumber,
                    Status = v.Status,
                    PricePerMinute = v.PricePerMinute,
                    BatteryLevel = v.BatteryLevel,
                    StationId = v.StationId,
                    StationName = v.Station != null ? v.Station.Name : "N/A",
                })
                .FirstOrDefault();

            if (vehicle == null) return NotFound();

            return View(vehicle);
        }
        public IActionResult Filter(string search, string vehicleType, string status)
        {
            var data = _context.Vehicles.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                data = data.Where(x => x.PlateNumber.Contains(search));

            if (!string.IsNullOrEmpty(vehicleType))
                data = data.Where(x => x.VehicleType == vehicleType);

            if (!string.IsNullOrEmpty(status))
                data = data.Where(x => x.Status == status);

            var result = data.Select(v => new AdminVehicleViewModel
            {
                Id = v.Id,
                VehicleType = v.VehicleType,
                PlateNumber = v.PlateNumber,
                Status = v.Status,
                PricePerMinute = v.PricePerMinute,
                StationId = v.StationId,
                BatteryLevel = v.BatteryLevel,
                StationName = v.Station != null ? v.Station.Name : "N/A"
            }).ToList();

            return PartialView("_VehicleTable", result);
        }
    }
}