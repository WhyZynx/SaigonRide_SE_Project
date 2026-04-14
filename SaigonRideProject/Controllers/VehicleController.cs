using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using SaigonRideProject.Models;

namespace SaigonRideProject.Controllers
{
    public class VehicleController : Controller
    {
        private readonly AppDbContext _context;

        public VehicleController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Vehicles.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Delete(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}