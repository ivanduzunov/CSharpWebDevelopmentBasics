using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyCoolWebServer.ByTheCakeApplication.Views;
using MyCoolWebServer.Server.Enums;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var indexHtml = File.ReadAllText(@"ByTheCakeApplication\Resourses\index.html");

            return new ViewResponse
                (HttpStatusCode.Ok, new IndexView(indexHtml));
        }

        public IHttpResponse About()
        {
            var indexHtml = File.ReadAllText(@"ByTheCakeApplication\Resourses\about.html");

            return new ViewResponse
                (HttpStatusCode.Ok, new IndexView(indexHtml));
        }


    }
}
