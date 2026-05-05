using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services;
using SaigonRideProject.ViewModels;
using System.Text.RegularExpressions;

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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var emailExists = _context.Users.Any(u => u.Email == model.Email.Trim().ToLower());

            if (emailExists)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(model);
            }

            var user = new User
            {
                FullName = model.FullName.Trim(),
                Email = model.Email.Trim().ToLower(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                IsVerified = false,
                Role = "User",
                UserType = "Pending",
                IdentityType = null,
                PassportStatus = "Pending"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("TempUserId", user.Id);

            return RedirectToAction("SelectUserType");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public IActionResult SelectUserType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectUserType(string userType)
        {
            if (userType != "Local" && userType != "Tourist")
            {
                ViewBag.Error = "Invalid user type";
                return View();
            }
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

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            if (string.IsNullOrWhiteSpace(identityNumber))
            {
                ViewBag.Error = "Identity number is required";
                return View();
            }

            if (user.UserType == "Local")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(identityNumber, @"^\d{12}$"))
                {
                    ViewBag.Error = "CCCD must be exactly 12 digits";
                    return View();
                }
            }
            else if (user.UserType == "Tourist")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(identityNumber, @"^[A-Z0-9]{6,12}$"))
                {
                    ViewBag.Error = "Passport format is invalid";
                    return View();
                }
            }

            if (file == null || file.Length == 0)
            {
                ViewBag.Error = "File is required";
                return View();
            }

            var allowed = new[] { ".jpg", ".png", ".pdf" };
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!allowed.Contains(extension))
            {
                ViewBag.Error = "Invalid file format";
                return View();
            }

            if (file.Length > 5 * 1024 * 1024)
            {
                ViewBag.Error = "File too large (max 5MB)";
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

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Success = TempData["Success"];
            ViewBag.Error = TempData["Error"];
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            if (!user.IsVerified)
            {
                ViewBag.Error = "Please verify OTP first";
                return View();
            }

            if (string.IsNullOrEmpty(user.UserType))
            {
                ViewBag.Error = "Please complete onboarding (User Type)";
                return View();
            }

            //if (string.IsNullOrEmpty(user.IdentityNumber))
            //{
            //    ViewBag.Error = "Please complete identity verification";
            //    return View();
            //}

            if (user.PassportStatus != "Approved")
            {
                ViewBag.Error = "Identity verification is pending approval";
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

        [HttpGet]
        public IActionResult ForgotPassword(string email = null)
        {
            ViewBag.Email = email;

            ViewBag.Error = TempData["Error"];
            ViewBag.Success = TempData["Success"];

            return View();
        }

        [HttpPost]
        public IActionResult SendForgotOtp(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                TempData["Error"] = "Email is required";
                return RedirectToAction("ForgotPassword");
            }

            email = email.Trim().ToLower();

            var user = _context.Users.FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                TempData["Error"] = "Email not found";
                return RedirectToAction("ForgotPassword");
            }

            var otp = GenerateOtp();

            _context.OtpVerifications.Add(new OtpVerification
            {
                Email = email,
                OtpCode = otp,
                ExpiryTime = DateTime.Now.AddMinutes(5)
            });

            _context.SaveChanges();

            _emailService.SendOtpEmail(email, otp);

            TempData["Success"] = "OTP sent successfully";

            return RedirectToAction("ForgotPassword", new { email = email });
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            var email = model.Email?.Trim().ToLower();

            if (string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "Email is required";
                return RedirectToAction("ForgotPassword", new { email });
            }

            var user = _context.Users.FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                TempData["Error"] = "Email is not registered";
                return RedirectToAction("ForgotPassword");
            }

            var otp = _context.OtpVerifications.FirstOrDefault(x =>
                x.Email == email &&
                x.OtpCode == model.OtpCode &&
                x.ExpiryTime > DateTime.Now);

            if (otp == null)
            {
                TempData["Error"] = "Invalid or expired OTP";
                return RedirectToAction("ForgotPassword", new { email });
            }

            if (BCrypt.Net.BCrypt.Verify(model.NewPassword, user.PasswordHash))
            {
                TempData["Error"] = "New password cannot be the same as old password";
                return RedirectToAction("ForgotPassword", new { email });
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                TempData["Error"] = "Passwords do not match";
                return RedirectToAction("ForgotPassword", new { email });
            }

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Password does not meet security requirements";
                return RedirectToAction("ForgotPassword", new { email });
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);

            var allOtp = _context.OtpVerifications.Where(x => x.Email == email);
            _context.OtpVerifications.RemoveRange(allOtp);

            _context.SaveChanges();

            TempData["Success"] = "Password reset successful!";
            return RedirectToAction("Login");
        }


    }
}