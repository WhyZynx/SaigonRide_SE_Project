using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;

namespace SaigonRideProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult PassportRequests()
        {
            var list = _context.Users
                .Where(x => x.UserType == "Tourist" && x.PassportStatus == "Pending")
                .ToList();

            return View(list);
        }

        public IActionResult Approve(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return RedirectToAction("PassportRequests");

            user.PassportStatus = "Approved";
            _context.SaveChanges();

            return RedirectToAction("PassportRequests");
        }

        public IActionResult Reject(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            user.PassportStatus = "Rejected";
            _context.SaveChanges();

            return RedirectToAction("PassportRequests");
        }
    }
}