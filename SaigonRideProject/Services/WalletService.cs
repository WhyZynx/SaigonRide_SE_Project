using SaigonRideProject.Data;
using SaigonRideProject.Models;

namespace SaigonRideProject.Services
{
    public class WalletService
    {
        private readonly AppDbContext _context;

        public WalletService(AppDbContext context)
        {
            _context = context;
        }

        public bool CanPay(User user, decimal amount)
        {
            return user.Balance >= amount && !user.IsLocked;
        }

        public void Pay(User user, decimal amount, string method)
        {
            if (user.Balance < amount)
                throw new Exception("Insufficient balance");

            user.Balance -= amount;

            _context.WalletTransactions.Add(new WalletTransaction
            {
                UserId = user.Id,
                Amount = -amount, 
                Type = "Payment",
                Method = method,
                CreatedAt = DateTime.Now
            });

            _context.SaveChanges();
        }

        public void TopUp(User user, decimal amount, string method)
        {
            user.Balance += amount;

            _context.WalletTransactions.Add(new WalletTransaction
            {
                UserId = user.Id,
                Amount = amount,
                Type = "TopUp",
                Method = method,
                CreatedAt = DateTime.Now
            });

            _context.SaveChanges();
        }
    }
}