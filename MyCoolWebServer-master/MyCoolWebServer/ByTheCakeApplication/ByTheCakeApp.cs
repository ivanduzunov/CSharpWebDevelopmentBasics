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

            appRouteConfig.Get
                ("/add", req => new CakesController().Add());

            appRouteConfig.Post
                ("add", req => new CakesController().Add(req.FormData["name"], req.FormData["price"]));

            appRouteConfig.Get
                ("/search", req => new CakesController().Search());

            appRouteConfig.Post
                ("/search", req => new CakesController().Search(req.FormData["searchName"]));

            appRouteConfig.Get
                ("/login", req => new AccountController().Login());

            appRouteConfig.Post
                ("/login", req => new AccountController().Login(req));

            appRouteConfig.Get
                ("/shopping/add/{(?<id>[0-9]+)}", req => new ShoppingController().AddToCard(req));
        }
    }
}
