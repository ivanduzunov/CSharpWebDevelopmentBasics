using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolCompetition
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var categories = new Dictionary<string, SortedSet<string>>();
            var results = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var elements = input.Split().ToArray();

                var name = elements[0];
                var category = elements[1];
                var points = int.Parse(elements[2]);

                if (!categories.ContainsKey(name))
                {
                    categories.Add(name, new SortedSet<string>());
                }

                categories[name].Add(category);

                if (!results.ContainsKey(name))
                {
                    results.Add(name, points);
                }
                else
                {
                    results[name] += points;
                }
            }

            var orderedResults = results.OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key);


            foreach (var player in orderedResults)
            {
                var name = player.Key;
                var points = player.Value;
                var playerCategories = categories[name];
                var categoriesText = $"[{string.Join(", ", playerCategories)}]";

                Console.WriteLine($"{name}: {points} {categoriesText}");
            }
        }
    }
}