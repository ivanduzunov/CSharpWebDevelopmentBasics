using System;
using System.Collections.Generic;
using System.Text;
using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;

namespace MyCoolWebServer.GameStoreApplication.Servises.Contracts
{
    public interface IGameServise
    {
        void Create(
            string title,
            string description,
            string image,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        IEnumerable<AdminListGameViewModel> All();
    }
}
