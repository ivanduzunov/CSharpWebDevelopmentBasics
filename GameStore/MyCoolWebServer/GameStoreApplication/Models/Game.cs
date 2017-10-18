using MyCoolWebServer.GameStoreApplication.Models;

namespace MyCoolWebServer.GameStoreApplication.Models
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstrants.Game.TitleMinLength)]
        [MaxLength(ValidationConstrants.Game.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstrants.Game.VideoIdLength)]
        [MaxLength(ValidationConstrants.Game.VideoIdLength)]
        public string VideoId { get; set; }

        [Required]
        public string Image { get; set; }

        // In GB
        public double Size { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MinLength(ValidationConstrants.Game.DescriptionMinLength)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<UserGame> Users { get; set; } = new List<UserGame>();
    }
}