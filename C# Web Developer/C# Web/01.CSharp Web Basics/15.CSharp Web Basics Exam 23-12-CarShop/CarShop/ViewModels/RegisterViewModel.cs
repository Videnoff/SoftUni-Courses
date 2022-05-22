using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} can't be null or whitespace")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} must be between {2} and {1}")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Must be a valid Email Address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} can't be null or whitespace")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1}")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword must be equal")]
        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
    }
}