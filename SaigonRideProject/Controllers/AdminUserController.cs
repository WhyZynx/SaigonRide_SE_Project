using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace SaigonRideProject.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly AppDbContext _context;

        public AdminUserController(AppDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }
        public IActionResult Index(string search, string userType, string status)
        {
            var data = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                data = data.Where(x =>
                    x.FullName.Contains(search) ||
                    x.Email.Contains(search));

            if (!string.IsNullOrEmpty(userType))
                data = data.Where(x => x.UserType == userType);

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Active")
                    data = data.Where(x => x.IsVerified && !x.IsLocked);
                else if (status == "Suspended")
                    data = data.Where(x => x.IsLocked);
            }

            var model = data.Select(x => new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                UserType = x.UserType,
                IsVerified = x.IsVerified,
                IsLocked = x.IsLocked,
                IdentityImageUrl = x.IdentityImageUrl,
                IdentityType = x.IdentityType,
                PassportStatus = x.PassportStatus,
                Balance = x.Balance
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model, string password)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            model.PasswordHash = HashPassword(password);
            model.Role = "User";
            model.IsVerified = true;

            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            var vm = new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserType = user.UserType,
                IsVerified = user.IsVerified,
                IsLocked = user.IsLocked,
                IdentityNumber = user.IdentityNumber,
                IdentityImageUrl = user.IdentityImageUrl,
                IdentityType = user.IdentityType,
                PassportStatus = user.PassportStatus,
                Balance = user.Balance
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel vm)
        {
            var user = _context.Users.Find(vm.Id);
            if (user == null) return NotFound();

            user.FullName = vm.FullName;
            user.UserType = vm.UserType;
            user.IsVerified = vm.IsVerified;
            user.IsLocked = vm.IsLocked;
            user.PassportStatus = vm.PassportStatus;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.IsLocked = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(sha.ComputeHash(bytes));
        }

        public IActionResult Detail(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null) return NotFound();

            return View(user);
        }

        public IActionResult Filter(string search, string userType, string status)
        {
            var data = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                data = data.Where(x =>
                    x.FullName.Contains(search) ||
                    x.Email.Contains(search));

            if (!string.IsNullOrEmpty(userType))
                data = data.Where(x => x.UserType == userType);

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Active")
                    data = data.Where(x => x.IsVerified && !x.IsLocked);
                else if (status == "Suspended")
                    data = data.Where(x => x.IsLocked);
            }

            var result = data.Select(x => new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                UserType = x.UserType,
                IsVerified = x.IsVerified,
                IsLocked = x.IsLocked,
                PassportStatus = x.PassportStatus
            }).ToList();

            return PartialView("_UserTable", result);
        }

        public IActionResult Unlock(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.IsLocked = false;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Approve(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.PassportStatus = "Approved";
            user.IsVerified = true;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}