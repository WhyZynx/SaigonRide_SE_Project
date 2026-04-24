using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class AdminVehicleController : Controller
    {
        private readonly AppDbContext _context;

        public AdminVehicleController(AppDbContext context)
        {
            _context = context;
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
                StationId = v.StationId
            }).ToList();

            return View(result);
        }

        public IActionResult Create()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            if (string.IsNullOrEmpty(vehicle.PlateNumber))
                return View(vehicle);

            vehicle.Status = "Available";

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

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
                    StationId = v.StationId
                })
                .FirstOrDefault();

            if (vehicle == null) return NotFound();

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
                    StationId = v.StationId,
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
                StationId = v.StationId
            }).ToList();

            return PartialView("_VehicleTable", result);
        }
    }
}