using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoolWebServer.GameStoreApplication.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MinLength(20)]
        [MaxLength(200)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string TrailerId { get; set; }

        [Required]
        public int Image { get; set; }

        [Required]
        public double Size { get; set; }

        public List<UserGame> Users { get; set; } = new List<UserGame>();
    }
}
