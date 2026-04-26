using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SaigonRideProject.ViewModels
{
    public class RegisterViewModel : IValidatableObject
    {
        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!Regex.IsMatch(Password ?? "", @"[A-Z]"))
                errors.Add(new ValidationResult("Password must contain at least 1 uppercase letter"));

            if (!Regex.IsMatch(Password ?? "", @"[0-9]"))
                errors.Add(new ValidationResult("Password must contain at least 1 number"));


            if (!string.IsNullOrEmpty(Email) && Email.Contains(" "))
                errors.Add(new ValidationResult("Email cannot contain spaces"));

            return errors;
        }
    }
}