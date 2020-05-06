using System;
using System.IO;

namespace _06.Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(".");

            var totalLength = 0m;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                totalLength += fileInfo.Length;
            }

            Console.WriteLine($"{totalLength / 1024 / 1024:F4} MB");
        }
    }
}
