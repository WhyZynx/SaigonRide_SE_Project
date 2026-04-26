using System.ComponentModel.DataAnnotations;

namespace SaigonRideProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public required string FullName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        [Required]
        public required string UserType { get; set; }

        [Required]
        public string Role { get; set; } = "User";

        public bool IsVerified { get; set; }
        public string? IdentityNumber { get; set; }
        public string? IdentityImageUrl { get; set; }
        public string IdentityType { get; set; } = "None";

        public string PassportStatus { get; set; } = "Pending";

        public decimal Balance { get; set; } = 0;

        public bool IsLocked { get; set; } = false;
        public List<WalletTransaction> WalletTransactions { get; set; } = new List<WalletTransaction>();
        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}