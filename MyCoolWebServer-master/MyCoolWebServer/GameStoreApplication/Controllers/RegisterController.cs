using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Views;
using MyCoolWebServer.Server.Contracts;
using MyCoolWebServer.Server.Routing.Contracts;
using MyCoolWebServer.Server.Enums;
using MyCoolWebServer.Server.Http;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    public class RegisterController
    {
        public IHttpResponse Index()
        {
            var loginHtml = File.ReadAllText(@"GameStoreApplication\Resourses\register.html");

            return new ViewResponse
                (HttpStatusCode.Ok, new IndexView(loginHtml));
        }


        
    }
}
