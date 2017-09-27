using System;
using System.Collections.Generic;

namespace _03.RequestParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> dict
                = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

                var path = tokens[0] + " HTTP";
                var method = tokens[1];

                if (!dict.ContainsKey(method))
                {
                    dict.Add(method, new HashSet<string>());
                }

                dict[method].Add(path);
            }

            var request = Console.ReadLine().Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            var requestedMethod = request[0].ToLower().Trim();
            var requestedPath = request[1];

            bool isCorrect 
                = dict.ContainsKey(requestedMethod) && dict[requestedMethod].Contains(requestedPath);

            if (isCorrect)
            {
                Console.WriteLine
                    ("HTTP/1.1 200 OK\nContent-Length: 2\nContent-Type: text/plain\n\nOK");
            }
            else
            {
                Console.WriteLine
                    ("HTTP/1.1 404 NotFound\nContent-Length: 9\nContent-Type: text/plain\n\nNotFound");
            }
        }
    }
}
