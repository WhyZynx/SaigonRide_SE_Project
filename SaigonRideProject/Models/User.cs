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

        public bool IsVerified { get; set; }

        public string? PassportNumber { get; set; }

        public string? PassportImageUrl { get; set; }

        public string PassportStatus { get; set; } = "Pending";
    }
}