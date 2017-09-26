using System;
using System.Net;

namespace _01.URLDecode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var encodedURL = Console.ReadLine();

            var decodedURL = WebUtility.UrlDecode(encodedURL);

            Console.WriteLine(decodedURL);
        }
    }
}
