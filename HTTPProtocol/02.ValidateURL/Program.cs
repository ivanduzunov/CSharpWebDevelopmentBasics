using System;
using System.Net;

namespace _02.ValidateURL
{
    class Program
    {
        static void Main(string[] args)
        {
            var encodedURL = Console.ReadLine();

            var decodedURL = WebUtility.UrlDecode(encodedURL);

            Uri uri = new Uri(decodedURL);

            //"Protocol: {protocol}"
            //"Host: {host}"
            //"Port: {port}"
            //"Path: {path}"
            //"Query: {query string}"(if any)
            //"Fragment: {fragment}"(if any)

            if (uri.Scheme == null || uri.Host == null || uri.Port == 0 || uri.AbsolutePath == null)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                Console.WriteLine($"Protocol: {uri.Scheme}");
                Console.WriteLine($"Host: {uri.Host}");
                Console.WriteLine($"Port: {uri.Port}");
                Console.WriteLine($"Path: {uri.AbsolutePath}");

                if (uri.Query!= "")
                {
                    Console.WriteLine($"Query: {uri.Query}");
                }
                if (uri.Fragment != "")
                {
                    Console.WriteLine($"Fragment: {uri.Fragment}");
                }
            }
        }
    }
}
