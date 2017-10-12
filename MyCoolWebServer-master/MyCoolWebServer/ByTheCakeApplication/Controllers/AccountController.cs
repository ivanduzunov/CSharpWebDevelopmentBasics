using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyCoolWebServer.ByTheCakeApplication.Views;
using MyCoolWebServer.Server.Enums;
using MyCoolWebServer.Server.Http;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using Models;

    public class AccountController
    {
        public IHttpResponse Login()
        {
            var loginHtml = File.ReadAllText(@"ByTheCakeApplication\Resourses\Account\login.html");

            return new ViewResponse
                (HttpStatusCode.Ok, new IndexView(loginHtml.Replace("{{{message}}}", string.Empty)));
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            var loginHtml = File.ReadAllText(@"ByTheCakeApplication\Resourses\Account\login.html");

            const string formNameKey = "username";
            const string formPasswordKey = "password";
            const string errorMessage = "Invalid data! Put Username/Password";

            if (!req.FormData.ContainsKey(formNameKey) || !req.FormData.ContainsKey(formPasswordKey))
            {
                return new ViewResponse
                (HttpStatusCode.Ok, new IndexView
                    (loginHtml.Replace("{{{message}}}", errorMessage)));
            }

            var username = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            req.Session.Add(SessionStore.CurrentUserKey, username);
            req.Session.Add(SessionStore.SessionCookieKey, new ShoppingCard());
            return new RedirectResponse("/");
        }
    }
}
