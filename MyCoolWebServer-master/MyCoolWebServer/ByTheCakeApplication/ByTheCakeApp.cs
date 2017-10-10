using System;
using System.Collections.Generic;
using System.Text;
using MyCoolWebServer.ByTheCakeApplication.Controllers;
using MyCoolWebServer.Server.Contracts;
using MyCoolWebServer.Server.Routing.Contracts;

namespace MyCoolWebServer.ByTheCakeApplication
{
    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get
                ("/", req => new HomeController().Index());

            appRouteConfig.Get
                ("/about", req => new HomeController().About());
        }
    }
}
