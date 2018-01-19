namespace ExamApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Class { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public int CustomerId { get; set; }

        public User Customer { get; set; }

        public int FlightId { get; set; }
            
        public Flight Flight { get; set; }

        public bool IsDeleted { get; set; }
    }
}
