using System;

namespace Orders
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0.0;
            price = Orders(product, quantity, price);
            Console.WriteLine($"{price:F2}");
        }

        private static double Orders(string product, int quantity, double price)
        {
            if (product == "coffee")
            {
                price = quantity * 1.50;
            }
            else if (product == "water")
            {
                price = quantity * 1.00;
            }
            else if (product == "coke")
            {
                price = quantity * 1.40;
            }
            else if (product == "snacks")
            {
                price = quantity * 2.00;
            }

            return price;
        }
    }
}
