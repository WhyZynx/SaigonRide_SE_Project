using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services;
using System.Security.Cryptography;
using System.Text;

namespace SaigonRideProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;

        public AccountController(
            AppDbContext context,
            EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        private void SetUserSession(User user)
        {
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Email", user.Email);
            HttpContext.Session.SetString("UserType", user.UserType);
            HttpContext.Session.SetString("Role", user.Role);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                ViewBag.Error = "Email is required";
                return View(user);
            }

            if (user.PasswordHash is null || user.PasswordHash.Length < 6)
            {
                ViewBag.Error = "Password must be at least 6 characters";
                return View(user);
            }

            if (user.PasswordHash != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View(user);
            }

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ViewBag.Error = "Email already exists";
                return View(user);
            }

            if (user.UserType == "Tourist" && string.IsNullOrWhiteSpace(user.PassportNumber))
            {
                ViewBag.Error = "Passport is required for tourists";
                return View(user);
            }

            var rawPassword = user.PasswordHash;

            user.PasswordHash = HashPassword(rawPassword);
            user.IsVerified = false;
            user.PassportStatus = "Pending";
            user.Role = "User";

            _context.Users.Add(user);

            var otp = new OtpVerification
            {
                Email = user.Email,
                OtpCode = GenerateOtp(),
                ExpiryTime = DateTime.Now.AddMinutes(5)
            };

            _context.OtpVerifications.Add(otp);
            _context.SaveChanges();

            _emailService.SendOtpEmail(user.Email, otp.OtpCode);

            HttpContext.Session.SetString("VerifyEmail", user.Email);

            return RedirectToAction("VerifyOtp");
        }

        public IActionResult VerifyOtp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifyOtp(string otpCode)
        {
            var email = HttpContext.Session.GetString("VerifyEmail");

            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Register");

            var otp = _context.OtpVerifications.FirstOrDefault(o =>
                o.Email == email &&
                o.OtpCode == otpCode &&
                o.ExpiryTime > DateTime.Now)
                ?? null;

            if (otp == null)
            {
                ViewBag.Error = "Invalid or expired OTP";
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email)
                ?? null;

            if (user == null)
                return RedirectToAction("Register");

            user.IsVerified = true;

            _context.OtpVerifications.Remove(otp);
            _context.SaveChanges();

            SetUserSession(user);

            if (user.UserType == "Tourist")
                return RedirectToAction("UploadPassport", "Passport");

            return RedirectToAction("UserDashboard", "User");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var hashed = HashPassword(password);

            var user = _context.Users.FirstOrDefault(u =>
                u.Email == email && u.PasswordHash == hashed);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            if (!user.IsVerified)
            {
                ViewBag.Error = "Please verify OTP first";
                return View();
            }
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.FullName);
            HttpContext.Session.SetString("Balance", user.Balance.ToString("N0"));

            SetUserSession(user);

            return user.Role == "Admin"
                ? RedirectToAction("Dashboard", "Admin")
                : RedirectToAction("UserDashboard", "User");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private static string GenerateOtp()
        {
            return Random.Shared.Next(100000, 999999).ToString();
        }

        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}