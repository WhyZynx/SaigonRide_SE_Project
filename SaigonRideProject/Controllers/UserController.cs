using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;

namespace SaigonRideProject.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult TopUp(decimal amount)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.Find(userId);

            if (user == null)
                return NotFound();

            if (amount <= 0)
                return BadRequest("Invalid amount");

            user.Balance += amount;

            HttpContext.Session.SetString("Balance", user.Balance.ToString());

            if (user.Balance >= 0)
                user.IsLocked = false;

            _context.SaveChanges();

            return RedirectToAction("UserDashboard", "Home");
        }
    }
}