namespace ExamApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string FullName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
