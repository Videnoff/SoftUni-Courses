using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDir = Console.ReadLine();

            string[] files = Directory.GetFiles(inputDir);

            Dictionary<string, Dictionary<string, double>> info = new Dictionary<string, Dictionary<string, double>>();

            foreach (var filePath in files)
            {
                string fileName = filePath.Split('\\').Last();

                string ext = "." + fileName.Split('.').Last();
            }
        }
    }
}
