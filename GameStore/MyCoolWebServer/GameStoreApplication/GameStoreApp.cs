using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyCoolWebServer.GameStoreApplication.Controllers;
using MyCoolWebServer.GameStoreApplication.Data;
using MyCoolWebServer.GameStoreApplication.ViewModels.Account;
using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;
using MyCoolWebServer.Server.Contracts;
using MyCoolWebServer.Server.Routing.Contracts;


namespace MyCoolWebServer.GameStoreApplication
{
    public class GameStoreApp : IApplication
    {


        public void InitializeDatabase()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPaths.Add("/");
            appRouteConfig.AnonymousPaths.Add("/account/register");
            appRouteConfig.AnonymousPaths.Add("/account/login");

            appRouteConfig
                .Get(
                    "/account/register",
                    req => new AccountController(req).Register());

            appRouteConfig
                .Post(
                    "/account/register",
                    req => new AccountController(req).Register(
                        new RegisterViewMoodel
                        {
                            Email = req.FormData["email"],
                            FullName = req.FormData["full-name"],
                            Password = req.FormData["password"],
                            ConfirmPassword = req.FormData["confirm-password"]
                        }));


            appRouteConfig
                .Get(
                    "/account/login",
                    req => new AccountController(req).Login());

            appRouteConfig
                .Post
                ("/account/login",
                req => new AccountController(req).Login(
                    new LoginViewModel
                    {
                        Email = req.FormData["email"],
                        Password = req.FormData["password"],
                    }
                ));

            appRouteConfig
                .Get(
                    "/game/add",
                    req => new AdminController(req).AddGame());

            appRouteConfig
                .Post
                ("/game/add",
                    req => new AdminController(req).AddGame(
                        new AdminAddGameViewModel
                        {
                           Description = req.FormData["description"],
                           Image = req.FormData["thumbnail"],
                           Price = decimal.Parse(req.FormData["price"]),
                           ReleaseDate = DateTime.Parse(req.FormData["release-date"]),
                           Size = double.Parse(req.FormData["size"]),
                           Title = req.FormData["title"],
                           VideoId = req.FormData["video-id"]
                        }
                    ));

        }
    }
}
