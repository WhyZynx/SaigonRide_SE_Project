using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;
using SaigonRideProject.ViewModels;
using Microsoft.EntityFrameworkCore;

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
            var today = DateTime.Today;

            var todayRevenue = _context.Rentals
                .Where(r => r.Status == "Completed" && r.EndTime >= today)
                .Sum(r => (decimal?)r.FinalAmount) ?? 0;

            var activeRentals = _context.Rentals
                .Count(r => r.Status == "InProgress");

            var availableVehicles = _context.Vehicles
                .Count(v => v.Status == "Available");

            var totalTransactions = _context.WalletTransactions.Count();

            var lowStations = _context.Stations
                .Where(s => s.CurrentInventory < s.Capacity * 0.2)
                .Select(s => new StationStatusViewModel
                {
                    StationName = s.Name,
                    Capacity = s.Capacity,
                    Current = s.CurrentInventory,
                    Status = "Low"
                }).ToList();

            var recentTransactions = _context.WalletTransactions
                .Include(t => t.User)
                .OrderByDescending(t => t.CreatedAt)
                .Take(5)
                .Select(t => new AdminTransactionViewModel
                {
                    Id = t.Id,
                    UserName = t.User.FullName,
                    Amount = t.Amount,
                    Type = t.Type,
                    CreatedAt = t.CreatedAt
                }).ToList();

            var liveRentals = _context.Rentals
                .Include(r => r.User)
                .Include(r => r.Vehicle)
                .Where(r => r.Status == "InProgress")
                .Select(r => new LiveRentalViewModel
                {
                    UserName = r.User.FullName,
                    Vehicle = r.Vehicle.PlateNumber,
                    StartTime = r.StartTime
                }).ToList();

            var model = new AdminDashboardViewModel
            {
                TodayRevenue = todayRevenue,
                ActiveRentals = activeRentals,
                AvailableVehicles = availableVehicles,
                TotalTransactions = totalTransactions,
                LowStations = lowStations,
                RecentTransactions = recentTransactions,
                LiveRentals = liveRentals
            };

            return View(model);
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