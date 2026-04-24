using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.ViewModels;

namespace SaigonRideProject.Controllers
{
    public class AdminTransactionController : Controller
    {
        private readonly AppDbContext _context;

        public AdminTransactionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Rentals
                .Include(r => r.User)
                .Include(r => r.Vehicle)
                .Where(r => r.Status == "Completed")
                .Select(r => new AdminTransactionViewModel
                {
                    Id = r.Id,
                    UserName = r.User.FullName,
                    Amount = r.FinalAmount,
                    VehicleType = r.Vehicle.VehicleType,
                    EndTime = r.EndTime ?? DateTime.Now,
                    PaymentMethod = r.PaymentMethod
                })
                .OrderByDescending(r => r.EndTime)
                .ToList();

            return View(data);
        }
    }
}