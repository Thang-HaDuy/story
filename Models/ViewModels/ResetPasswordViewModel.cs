using System.ComponentModel.DataAnnotations;

namespace App.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password format.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "The password reset token is required.")]
        public string? Token { get; set; }
    }
}