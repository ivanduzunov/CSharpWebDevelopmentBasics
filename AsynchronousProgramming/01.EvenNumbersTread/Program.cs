using System;
using System.Linq;
using System.Threading;

namespace _01.EvenNumbersTread
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var tread = new Thread(() => PrintEvenNumbersInRange(input[0], input[1]));

            tread.Start();
            tread.Join();

            Console.WriteLine("Finished");
        }

        private static void PrintEvenNumbersInRange(int v1, int v2)
        {
            for (int i = v1; i < v2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
