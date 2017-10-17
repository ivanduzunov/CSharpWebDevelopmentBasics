using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MyCoolWebServer.GameStoreApplication.Models
{
    public class User
    {
        public int Id { get; set; }

       
        public string FullName { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public List<UserGame> Games { get; set; } = new List<UserGame>();
    }
}