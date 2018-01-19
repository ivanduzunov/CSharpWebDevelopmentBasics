namespace ExamApp.Web.Models.Admin
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateFlightModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Destination { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Origin { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
