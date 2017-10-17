using System;
using System.Collections.Generic;
using System.Text;
using MyCoolWebServer.Server.Contracts;

namespace MyCoolWebServer.GameStoreApplication.Views
{
    public class IndexView : IView
    {
        private readonly string htmlFile;

        public IndexView(string htmlFile)
        {
            this.htmlFile = htmlFile;
        }

        public string View() => this.htmlFile;
    }
}
