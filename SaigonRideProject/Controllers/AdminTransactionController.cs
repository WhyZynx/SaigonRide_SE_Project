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
            var data = _context.WalletTransactions
                .Include(t => t.User)
                .Select(t => new AdminTransactionViewModel
                {
                    Id = t.Id,
                    UserName = t.User.FullName,
                    Amount = t.Amount,
                    Type = t.Type,
                    Method = t.Method,
                    CreatedAt = t.CreatedAt
                }).ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult Filter(string search, string type)
        {
            var data = _context.WalletTransactions
                .Include(t => t.User)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
                data = data.Where(x =>
                    x.User.FullName.Contains(search) ||
                    x.Id.ToString().Contains(search));

            if (!string.IsNullOrEmpty(type))
                data = data.Where(x => x.Type == type);

            var result = data.Select(t => new AdminTransactionViewModel
            {
                Id = t.Id,
                UserName = t.User.FullName,
                Amount = t.Amount,
                Type = t.Type,
                Method = t.Method,
                CreatedAt = t.CreatedAt
            }).ToList();

            return PartialView("_TransactionTable", result);
        }
    }
}