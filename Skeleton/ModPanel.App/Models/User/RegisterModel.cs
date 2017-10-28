using System;
using System.Collections.Generic;
using System.Text;

namespace ModPanel.App.Models.User
{
    using Infrastructure.Validation;
    using Infrastructure.Validation.Users;
    using Data.Models;

    public class RegisterModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public int Position { get; set; }
    }
}
