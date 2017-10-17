using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Common;

namespace MyCoolWebServer.GameStoreApplication.Models
{
    public class User
    {
        public int Id { get; set; }

        [MinLength(ValidationConstrants.Account.NameMinLength)]
        [MaxLength(ValidationConstrants.Account.NameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MinLength(ValidationConstrants.Account.PasswordMinLength)]
        [MaxLength(ValidationConstrants.Account.PasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MaxLength(ValidationConstrants.Account.EmailMaxLength)]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public List<UserGame> Games { get; set; } = new List<UserGame>();
    }
}