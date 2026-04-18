using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;

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

        [HttpPost]
        public IActionResult Create(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var station = _context.Stations.Find(id);
            return View(station);
        }

        [HttpPost]
        public IActionResult Edit(Station station)
        {
            _context.Stations.Update(station);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var station = _context.Stations.Find(id);
            return View(station);
        }

        [HttpPost]
        public IActionResult Delete(Station station)
        {
            _context.Stations.Remove(station);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var station = _context.Stations
                .Include(s => s.Vehicles)
                .FirstOrDefault(s => s.Id == id);

            return View(station);
        }
    }
}