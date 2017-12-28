﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Models.User
{
    using Infrastructure.Validation;
    using Infrastructure.Validation.Users;


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

        public string FullName { get; set; }
    }
}