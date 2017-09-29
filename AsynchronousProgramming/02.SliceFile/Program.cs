
using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string videoPath = Console.ReadLine();
            string destination = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            SliceAsync(videoPath, destination, pieces);

            Console.WriteLine("Anything else?");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "No")
                {
                    break;
                }
            }
        }

        private static void SliceAsync(string videoPath, string destination, int pieces)
        {
            Task.Run(() => Slice(videoPath, destination, pieces));
        }

        static void Slice(string sourceFile, string destinationPath, int parts)
        {

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);
                long partLenght = (source.Length / parts) + 1;
                long currentByte = 0;

                for (int i = 1; i <= parts; i++)
                {
                    string filePath =
                        string.Format($"{destinationPath}/Part-{i}{fileInfo.Extension}");

                    using (var dest = new FileStream(filePath, FileMode.Create))
                    {
                        //new byte[BufferLenght];
                        byte[] buffer = new byte[filePath.Length];

                        while (currentByte <= partLenght * i)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }
                            dest.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }

                        Console.WriteLine("Slice Complete.");
                    }
                }
            }
        }     
    }
}
