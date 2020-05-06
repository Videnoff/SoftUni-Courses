using System;
using System.IO;

namespace _07.Print_Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\IvanV\source\repos\CSharp-Advanced-January2020";

            PrintDirectory(path, string.Empty);
        }

        static void PrintDirectory(string path, string prefix)
        {
            var directories = Directory.GetDirectories(path);
            var directoryInfo = new DirectoryInfo(path);

            Console.WriteLine($"{prefix} Dir: {directoryInfo.Name}");

            foreach (var directory in directories)
            {
                PrintDirectory(directory, prefix += "--");
            }

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                Console.WriteLine($"{prefix}-- File: {fileInfo.Name}");
            }
        }
    }
}
