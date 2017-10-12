using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using Models;

    public class ShoppingController
    {
        public IHttpResponse AddToCard(IHttpRequest req)
        {
            int idNumber = int.Parse(req.UrlParameters["id"]);

            var cake = FindById(idNumber);

            if (cake == null)
            {
                return new NotFoundResponse();
            }

            req.Session.Get<ShoppingCard>(ShoppingCard.SessionKey).Orders.Add(cake);

            return new RedirectResponse("/search");
        }

        private Cake FindById(int id)
        {
            using (StreamReader sr = new StreamReader(@"ByTheCakeApplication\Data\database.csv", true))
            {
                var result = sr.ReadToEnd().Split(Environment.NewLine).ToList();

                for (int i = 0; i < result.Count - 1; i++)
                {
                    var element = result[i].Split(',');

                    if (int.Parse(element[0]) == id)
                    {
                        Cake cake = new Cake()
                        {
                            Id = int.Parse(element[0]),
                            Name = element[1],
                            Price = decimal.Parse(element[2])
                        };
                        return cake;
                    }
                }
            }

            return null;
        }
    }
}
