using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Common;

namespace MyCoolWebServer.GameStoreApplication.ViewModels.Admin
{
    public class AdminAddGameViewModel
    {
        [Required]
        [MinLength(
            ValidationConstrants.Game.TitleMinLength,
            ErrorMessage = ValidationConstrants.InvalidMinLengthErrorMessage)]
        [MaxLength(
            ValidationConstrants.Game.TitleMaxLength,
            ErrorMessage = ValidationConstrants.InvalidMaxLengthErrorMessage)]
        public string Title { get; set; }

        [Display(Name = "YouTube Video URL")]
        [Required]
        [MinLength(
            ValidationConstrants.Game.VideoIdLength,
            ErrorMessage = ValidationConstrants.ExactLengthErrorMessage)]
        [MaxLength(
            ValidationConstrants.Game.VideoIdLength,
            ErrorMessage = ValidationConstrants.ExactLengthErrorMessage)]
        public string VideoId { get; set; }

        [Required]
        public string Image { get; set; }

        // In GB
        public double Size { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MinLength(
            ValidationConstrants.Game.DescriptionMinLength,
            ErrorMessage = ValidationConstrants.InvalidMinLengthErrorMessage)]
        public string Description { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}
