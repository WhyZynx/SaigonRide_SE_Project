using System.ComponentModel.DataAnnotations;

namespace SaigonRideProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public required string FullName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, MinLength(6)]
        public required string Password { get; set; }

        [Required, Compare("Password")]
        public required string ConfirmPassword { get; set; }

        [Required]
        public required string UserType { get; set; }

        public string? PassportNumber { get; set; }
    }
}