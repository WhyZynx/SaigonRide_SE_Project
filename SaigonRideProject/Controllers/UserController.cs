using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Payment;

namespace SaigonRideProject.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly WalletService _walletService;

        public UserController(AppDbContext context, WalletService walletService)
        {
            _context = context;
            _walletService = walletService;

        }

        [HttpPost]
        [HttpPost]
        public IActionResult TopUp(decimal amount, string method)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var user = _context.Users.Find(userId);

            if (user == null)
                return BadRequest("User not found");

            if (amount <= 0)
                return BadRequest("Invalid amount");

            var strategy = PaymentFactory.GetStrategy(user.UserType, method);

            var message = strategy.Pay(amount);

            user.Balance += amount;

            _context.SaveChanges();

            TempData["PaymentMessage"] = message;

            return RedirectToAction("UserDashboard", "Home");
        }

        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var user = _context.Users.Find(userId);

            return View(user);
        }

        public IActionResult TopUpPage()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.Find(userId);

            return View(user);
        }
    }
}