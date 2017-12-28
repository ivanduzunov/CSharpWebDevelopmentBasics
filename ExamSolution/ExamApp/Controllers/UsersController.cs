using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Controllers
{

    using Services;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using Models.User;

    public class UsersController : BaseController
    {
        private const string EmailError = "<p> E-mails must have at least one '@' and one '.' symbols.</p>";
        private const string PasswordError = "<p>Passwords must be at least 6 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit.</p>";
        private const string PasswordsNotMatchError = "<p>Confirm password must match the provided password.</p>";
        private const string EmailExistsError = "E-mail is already taken.";
        private const string LoginError = "<p>Invalid credentials.</p>";

        private readonly IUserService users;

        public UsersController()
        {
            this.users = new UserService();
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                this.ShowError(PasswordsNotMatchError);
                return this.View();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(EmailError);
                return this.View();
            }

            var result = this.users
               .Create(model.Email, model.Password, model.FullName);

            if (result)
            {
                return this.RedirectToLogin();
            }
            else
            {
                this.ShowError(EmailExistsError);
                return this.View();
            }

        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LogInModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(LoginError);
                return this.View();
            }

          
            if (this.users.UserExists(model.Email, model.Password))
            {
                this.SignIn(model.Email);
                return this.RedirectToHome();
            }
            else
            {
                this.ShowError(LoginError);
                return this.View();
            }
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToHome();
        }

    }
}
