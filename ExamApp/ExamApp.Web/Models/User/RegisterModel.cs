namespace ExamApp.Web.Models.User
{
    using Infrastructure.Validation;
    using Infrastructure.Validation.Users;

    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string RepeatPassword { get; set; }
    }
}
