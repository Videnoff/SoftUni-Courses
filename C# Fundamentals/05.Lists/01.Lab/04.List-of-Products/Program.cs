using System;
using System.Linq;
using System.Collections.Generic;

namespace ListofProducts
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int totalProducts = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < totalProducts; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
