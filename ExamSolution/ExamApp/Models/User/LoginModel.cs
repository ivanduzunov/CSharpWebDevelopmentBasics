using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Models.User
{
    using Infrastructure.Validation;

    public class LogInModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
