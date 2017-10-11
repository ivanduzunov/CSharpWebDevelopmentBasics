using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyCoolWebServer.ByTheCakeApplication.Models;
using MyCoolWebServer.ByTheCakeApplication.Views;
using MyCoolWebServer.Server.Enums;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    public class CakesController
    {
        private static readonly List<Cake> values = new List<Cake>();

        public IHttpResponse Add()
        {
            var indexHtml = File.ReadAllText(@"ByTheCakeApplication\Resourses\Cakes\add.html");

            return new ViewResponse
                (HttpStatusCode.Ok, new IndexView(indexHtml.Replace("{{{cakes}}}", string.Empty)));
        }

        public IHttpResponse Add(string name, string price)
        {
            var indexHtml = File.ReadAllText(@"ByTheCakeApplication\Resourses\Cakes\add.html");

            var cake = new Cake
            {
                Name = name,
                Price = decimal.Parse(price)
            };

            values.Add(cake);

            using (var streamWriter = new StreamWriter(@"ByTheCakeApplication\Data\database.csv", true))
            {
                streamWriter.WriteLine($"{cake.Name},{cake.Price}");
            }

            return new ViewResponse
                (HttpStatusCode.Ok, new IndexView(indexHtml.Replace("{{{cakes}}}", $"Added: {cake.Name} - {cake.Price}")));
        }

        public IHttpResponse Search()
        {
            var indexHtml = File.ReadAllText(@"ByTheCakeApplication\Resourses\Cakes\search.html");

            return new ViewResponse
                (HttpStatusCode.Ok, new IndexView(indexHtml.Replace("{{{cakes}}}", string.Empty)));
        }

        public IHttpResponse Search(string searchName)
        {
            var indexHtml = File.ReadAllText(@"ByTheCakeApplication\Resourses\Cakes\search.html");

            var searchResult = ExtractSearchedCakes(searchName);

            return new ViewResponse
                (HttpStatusCode.Ok, new IndexView(indexHtml.Replace("{{{cakes}}}", searchResult)));
        }

        private string ExtractSearchedCakes(string Sname)
        {

            var searchName = Sname.ToLower();

            var sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(@"ByTheCakeApplication\Data\database.csv", true))
            {

                var fullText = sr.ReadToEnd();

                var fullList = fullText.Split(Environment.NewLine).ToList();
                sb.AppendLine("<pre>");
                if (fullList.Count > 1)
                {
                   
                    for (int i = 0; i < fullList.Count - 1; i++)
                    {
                        var lineTokens = fullList[i].Split(',');
                        var name = lineTokens[0];
                        var price = lineTokens[1];

                        if (name.Contains(searchName.ToLower()))
                        {
                            sb.AppendLine($"Name: {name}  Price: {price}");
                        }
                    }
                }
                else
                {
                    sb.AppendLine("No results.");
                }
            }
            sb.AppendLine("</pre>");
            return sb.ToString();
        }
    }
}
