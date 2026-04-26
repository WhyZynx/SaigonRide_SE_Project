using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services;

namespace SaigonRideProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;

        public AccountController(AppDbContext context, EmailService emailService)
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
            HttpContext.Session.SetString("UserName", user.FullName);
        }

        // ================= REGISTER =================

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string confirmPassword)
        {
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

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.IsVerified = false;
            user.Role = "User";
            user.IdentityType = "None";
            user.PassportStatus = "Pending";

            _context.Users.Add(user);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("TempUserId", user.Id);

            return RedirectToAction("SelectUserType");
        }

        // ================= USER TYPE =================

        public IActionResult SelectUserType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectUserType(string userType)
        {
            var userId = HttpContext.Session.GetInt32("TempUserId");

            if (userId == null)
                return RedirectToAction("Register");

            var user = _context.Users.Find(userId);

            user.UserType = userType;

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

        // ================= OTP =================

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
                o.ExpiryTime > DateTime.Now);

            if (otp == null)
            {
                ViewBag.Error = "Invalid or expired OTP";
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            user.IsVerified = true;

            _context.OtpVerifications.Remove(otp);
            _context.SaveChanges();

            SetUserSession(user);

            return RedirectToAction("IdentityVerification");
        }

        // ================= IDENTITY =================

        public IActionResult IdentityVerification()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IdentityVerification(string identityNumber, IFormFile file)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login");

            var user = _context.Users.Find(userId);

            if (string.IsNullOrWhiteSpace(identityNumber))
            {
                ViewBag.Error = "Identity number is required";
                return View();
            }

            if (file == null || file.Length == 0)
            {
                ViewBag.Error = "File is required";
                return View();
            }

            var extension = Path.GetExtension(file.FileName).ToLower();
            var allowed = new[] { ".jpg", ".png", ".pdf" };

            if (!allowed.Contains(extension))
            {
                ViewBag.Error = "Invalid file format";
                return View();
            }

            if (file.Length > 5 * 1024 * 1024)
            {
                ViewBag.Error = "File too large";
                return View();
            }

            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/identity");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid() + extension;
            var path = Path.Combine(folder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            user.IdentityNumber = identityNumber;
            user.IdentityImageUrl = "/uploads/identity/" + fileName;
            user.IdentityType = user.UserType == "Local" ? "CCCD" : "Passport";
            user.PassportStatus = "Pending";

            _context.SaveChanges();

            return RedirectToAction("RegisterSuccess");
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }

        // ================= LOGIN =================

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            if (!user.IsVerified)
            {
                ViewBag.Error = "Please verify OTP first";
                return View();
            }

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
    }
}