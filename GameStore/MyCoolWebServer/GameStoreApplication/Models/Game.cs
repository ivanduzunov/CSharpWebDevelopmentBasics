using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Common;

namespace MyCoolWebServer.GameStoreApplication.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstrants.Game.TitleMinLength)]
        [MaxLength(ValidationConstrants.Game.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MinLength(20)]
        [MaxLength(ValidationConstrants.Game.DescriptionMinLength)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(ValidationConstrants.Game.VideoIdLength)]
        [MaxLength(ValidationConstrants.Game.VideoIdLength)]
        public string TrailerId { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public double Size { get; set; }

        public List<UserGame> Users { get; set; } = new List<UserGame>();
    }
}
