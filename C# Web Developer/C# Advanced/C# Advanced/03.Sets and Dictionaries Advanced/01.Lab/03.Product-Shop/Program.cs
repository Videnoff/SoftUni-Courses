using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var productShop = new Dictionary<string, Dictionary<string, double>>();

            /* Input:
             * lidl, juice, 2.30
             */

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] inputInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = inputInfo[0];
                string productName = inputInfo[1];
                double productPrice = double.Parse(inputInfo[2]);

                if (!productShop.ContainsKey(shopName))
                {
                    productShop.Add(shopName, new Dictionary<string, double>());
                }

                if (!productShop[shopName].ContainsKey(productName))
                {
                    productShop[shopName].Add(productName, productPrice);
                }

                //productShop[shopName].Add(productName, productPrice);


                input = Console.ReadLine();
            }

            /* Output:
             * kaufland->
               Product: banana, Price: 1.1
             */

            foreach (var (shopname, products) in productShop.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shopname}->");

                foreach (var currentProduct in products)
                {
                    Console.WriteLine($"Product: {currentProduct.Key}, Price: {currentProduct.Value}");
                }
            }
        }
    }
}
