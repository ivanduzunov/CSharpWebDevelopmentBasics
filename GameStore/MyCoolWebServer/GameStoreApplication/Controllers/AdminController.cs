using System;
using System.Collections.Generic;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Servises;
using MyCoolWebServer.GameStoreApplication.Servises.Contracts;
using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    public class AdminController : BaseController
    {
        private const string AddGameView = @"admin\add-game";
        private const string ListGamesView = @"admin\list-games";

        private readonly IGameServise games;

        public AdminController(IHttpRequest request)
            : base(request)
        {
            this.games = new GameServise();
        }

        public IHttpResponse AddGame()
        {
            if (this.Authentication.IsAdmin)
            {
                return FileViewResponse(AddGameView);
            }
            else
            {
                return new RedirectResponse(HomePath);
            }
        }

        public IHttpResponse AddGame(AdminAddGameViewModel model)
        {
            if (!ValidateModel(model))
            {
                return this.AddGame();
            }

            games.Create(model.Title, model.Description, model.Image, model.Price, model.Size,
                  model.VideoId, model.ReleaseDate);

            return new RedirectResponse(HomePath);
        }



    }
}
