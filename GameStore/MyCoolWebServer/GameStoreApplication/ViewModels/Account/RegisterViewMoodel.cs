using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Common;
using MyCoolWebServer.GameStoreApplication.Utilities;

namespace MyCoolWebServer.GameStoreApplication.ViewModels.Account
{
    public class RegisterViewMoodel
    {
        [Required]
        [Display(Name = "E-mail")]
        [MaxLength(ValidationConstrants.Account.EmailMaxLength,
            ErrorMessage = ValidationConstrants.InvalidMinLengthErrorMessage)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        [MinLength(
            ValidationConstrants.Account.NameMinLength,
            ErrorMessage = ValidationConstrants.InvalidMinLengthErrorMessage)]
        [MaxLength(
            ValidationConstrants.Account.NameMaxLength,
            ErrorMessage = ValidationConstrants.InvalidMaxLengthErrorMessage)]
        public string FullName { get; set; }

        [Required]
        [MinLength(
            ValidationConstrants.Account.PasswordMinLength,
            ErrorMessage = ValidationConstrants.InvalidMinLengthErrorMessage)]
        [MaxLength(
            ValidationConstrants.Account.PasswordMaxLength,
            ErrorMessage = ValidationConstrants.InvalidMaxLengthErrorMessage)]
        [Password]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
