using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Data;
using MyCoolWebServer.GameStoreApplication.Models;
using MyCoolWebServer.GameStoreApplication.Servises;
using MyCoolWebServer.GameStoreApplication.Servises.Contracts;
using MyCoolWebServer.GameStoreApplication.ViewModels.Account;
using MyCoolWebServer.GameStoreApplication.Views;
using MyCoolWebServer.Infrastructure;
using MyCoolWebServer.Server.Contracts;
using MyCoolWebServer.Server.Routing.Contracts;
using MyCoolWebServer.Server.Enums;
using MyCoolWebServer.Server.Http;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    public class AccountController : BaseController
    {
        private const string RegisterView = @"account\register";
        private const string LoginView = @"account\login";

        private readonly IUserServise users;

        public AccountController(IHttpRequest request)
            : base(request)
        {
            this.users = new UserServise();
        }

        public IHttpResponse Register()
            => this.FileViewResponse(RegisterView);

        public IHttpResponse Register(RegisterViewMoodel model)
        {
            if (!this.ValidateModel(model))
            {
                return this.Register();
            }

            var success = this.users
                .Create(model.Email, model.FullName, model.Password);

            if (!success)
            {
                this.ShowError("E-mail is taken.");
                return this.Register();
            }
            else
            {
                this.LoginUser(model.Email);
                return this.RedirectResponse(HomePath);
            }
        }

        public IHttpResponse Login()
            => this.FileViewResponse(LoginView);

        public IHttpResponse Login(LoginViewModel model)
        {
            if (!this.ValidateModel(model))
            {
                return this.Login();
            }

            var findUser = this.users.Find(model.Email, model.Password);

            if (!findUser)
            {
                this.ShowError("Can't find user with such a email!");
                return this.Login();
            }
            else
            {
                this.LoginUser(model.Email);
                return this.RedirectResponse(HomePath);
            }

        }

        private void LoginUser(string email)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, email);
        }
    }
}
