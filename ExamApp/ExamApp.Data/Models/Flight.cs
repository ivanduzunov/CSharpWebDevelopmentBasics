namespace ExamApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Flight
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Origin { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Destination { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsPublic { get; set; }

        public bool IsDeleted { get; set; }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
