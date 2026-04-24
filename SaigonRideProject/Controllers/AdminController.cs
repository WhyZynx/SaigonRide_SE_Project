using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using System.Linq;

namespace SaigonRideProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Users = _context.Users.Count();
            ViewBag.Vehicles = _context.Vehicles.Count();
            ViewBag.Stations = _context.Stations.Count();
            ViewBag.Revenue = _context.Rentals
                .Where(r => r.Status == "Completed")
                .Sum(r => (decimal?)r.FinalAmount) ?? 0;

            return View();
        }

        public IActionResult Lock(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.IsLocked = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Unlock(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.IsLocked = false;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}