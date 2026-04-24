using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Payment;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly WalletService _walletService;
        private readonly RentalService _rentalService;

        public UserController(AppDbContext context, WalletService walletService, RentalService rentalService)
        {
            _context = context;
            _walletService = walletService;
            _rentalService = rentalService;

        }
        public IActionResult UserDashboard()
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            var hasTrip = _rentalService.HasActiveRental(userId.Value);


            var user = _context.Users.Find(userId);

            var stations = _context.Stations.ToList();

            var model = new UserDashboardViewModel
            {
                User = user,
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