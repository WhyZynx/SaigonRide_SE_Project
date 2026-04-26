using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SaigonRideProject.ViewModels
{
    public class ForgotPasswordViewModel : IValidatableObject
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string OtpCode { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!string.IsNullOrEmpty(NewPassword))
            {
                if (NewPassword.Length < 8)
                    errors.Add(new ValidationResult("Password must be at least 8 characters", new[] { "NewPassword" }));

                if (!Regex.IsMatch(NewPassword, @"[A-Z]"))
                    errors.Add(new ValidationResult("Password must contain at least 1 uppercase letter", new[] { "NewPassword" }));

                if (!Regex.IsMatch(NewPassword, @"\d"))
                    errors.Add(new ValidationResult("Password must contain at least 1 number", new[] { "NewPassword" }));
            }

            return errors;
        }
    }
}