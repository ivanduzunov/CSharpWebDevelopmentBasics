using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyCoolWebServer.GameStoreApplication.Controllers;
using MyCoolWebServer.GameStoreApplication.Data;
using MyCoolWebServer.Server.Contracts;
using MyCoolWebServer.Server.Routing.Contracts;


namespace MyCoolWebServer.GameStoreApplication
{
    public class GameStoreApp : IApplication
    {
        

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get
                ("/", req => new RegisterController().Index());
        }

        public void InitializeDatabase()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
