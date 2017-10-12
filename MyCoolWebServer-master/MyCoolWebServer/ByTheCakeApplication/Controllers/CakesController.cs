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

            var strReader = new StreamReader(@"ByTheCakeApplication\Data\database.csv");

            var id = strReader.ReadToEnd().Split(Environment.NewLine).Length;

            strReader.Dispose();



            using (var streamWriter = new StreamWriter(@"ByTheCakeApplication\Data\database.csv", true))
            {
                streamWriter.WriteLine($"{id},{cake.Name},{cake.Price}");
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

                var result = sr.ReadToEnd().Split(Environment.NewLine).ToList();

                var resultList = new List<Cake>();

                for (int i = 0; i < result.Count - 1; i++)
                {
                    var element = result[i].Split(',');

                    if (element[1].ToLower().Contains(searchName))
                    {
                        resultList.Add(new Cake()
                        {
                            Id = int.Parse(element[0]),
                            Name = element[1],
                            Price = decimal.Parse(element[2])
                        });
                    }
                }

                if (resultList.Count > 1)
                {
                    foreach (var cake in resultList)
                    {
                        sb.AppendLine($@"<div>Name: {cake.Name}  Price: {cake.Price}<a href=""/shopping/add/{cake.Id}""> Order</a></div>");
                    }
                }
                else
                {
                    sb.AppendLine("<div>No results.</div>");
                }
            }

            return sb.ToString();
        }
    }
}
