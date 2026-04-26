using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Payment;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class UserController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly WalletService _walletService;
        private readonly RentalService _rentalService;

        public UserController(AppDbContext context, WalletService walletService, RentalService rentalService): base(context)
        {
            _context = context;
            _walletService = walletService;
            _rentalService = rentalService;

        }
        public IActionResult UserDashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(x => x.Id == userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var stations = _context.Stations.ToList();

            ViewBag.PaymentMethods = PaymentMethodProvider.Get(user.UserType);

            var model = new UserDashboardViewModel
            {
                User = user,
                UserType = user.UserType,
                Stations = stations.Select(s => new StationMapViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    AvailableCount = s.CurrentInventory
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult TopUp(decimal amount, string method)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(x => x.Id == userId.Value);

            if (user == null)
                return BadRequest("User not found");

            if (amount <= 0)
                return BadRequest("Invalid amount");

            var strategy = PaymentFactory.GetStrategy(user.UserType, method);

            var message = strategy.Pay(amount);

            _walletService.TopUp(user, amount, method);

            TempData["PaymentMessage"] = message;

            return RedirectToAction("UserDashboard", "User");
        }

        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(x => x.Id == userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user);
        }

        public IActionResult TopUpPage()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(x => x.Id == userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            ViewBag.PaymentMethods = PaymentMethodProvider.Get(user.UserType);

            return View(user);
        }

        public IActionResult Transactions()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var data = _context.WalletTransactions
                .Where(x => x.UserId == userId.Value)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            return View(data);
        }
    }
}