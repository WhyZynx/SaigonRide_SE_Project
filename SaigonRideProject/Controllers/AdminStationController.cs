using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class AdminStationController : Controller
    {
        private readonly AppDbContext _context;

        public AdminStationController(AppDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        public IActionResult Index(string search, string status)
        {
            var data = _context.Stations.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                data = data.Where(x => x.Name.Contains(search) || x.Address.Contains(search));

            if (!string.IsNullOrEmpty(status))
                data = data.Where(x => x.Status == status);

            var result = data.Select(s => new AdminStationViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Capacity = s.Capacity,
                CurrentInventory = s.CurrentInventory,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Status = s.Status
            }).ToList();

            return View(result);
        }

        public IActionResult Create()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Station station)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            _context.Stations.Add(station);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var station = _context.Stations
                .Where(s => s.Id == id)
                .Select(s => new AdminStationViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Capacity = s.Capacity,
                    CurrentInventory = s.CurrentInventory,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude

                })
                .FirstOrDefault();

            if (station == null) return NotFound();

            return View(station);
        }

        [HttpPost]
        public IActionResult Edit(AdminStationViewModel model)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var station = _context.Stations.Find(model.Id);

            if (station == null) return NotFound();

            station.Name = model.Name;
            station.Address = model.Address;
            station.Capacity = model.Capacity;
            station.CurrentInventory = model.CurrentInventory;
            station.Latitude = model.Latitude;
            station.Longitude = model.Longitude;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var station = _context.Stations
                .Where(s => s.Id == id)
                .Select(s => new AdminStationViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address
                })
                .FirstOrDefault();

            return View(station);
        }

        [HttpPost]
        public IActionResult Delete(AdminStationViewModel model)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var station = _context.Stations.Find(model.Id);

            if (station == null) return NotFound();

            _context.Stations.Remove(station);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var station = _context.Stations
                .Include(s => s.Vehicles)
                .FirstOrDefault(s => s.Id == id);

            if (station == null) return NotFound();

            var model = new AdminStationViewModel
            {
                Id = station.Id,
                Name = station.Name,
                Address = station.Address,
                Capacity = station.Capacity,
                CurrentInventory = station.CurrentInventory,
                Latitude = station.Latitude,
                Longitude = station.Longitude,
                Vehicles = station.Vehicles.ToList()
            };

            return View(model);
        }

        public IActionResult Filter(string search, string status)
        {
            var data = _context.Stations.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                data = data.Where(x => x.Name.Contains(search) || x.Address.Contains(search));

            if (!string.IsNullOrEmpty(status))
                data = data.Where(x => x.Status == status);

            var result = data.Select(s => new AdminStationViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Capacity = s.Capacity,
                CurrentInventory = s.CurrentInventory,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Status = s.Status
            }).ToList();

            return PartialView("_StationTable", result);
        }
    }
}