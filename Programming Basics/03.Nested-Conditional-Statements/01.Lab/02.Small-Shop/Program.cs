using System;

namespace SmallShop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine()
                                 ;
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;

            if (town == "Sofia")
            {
                if (product == "coffee")
                {
                    price = quantity * 0.50;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = quantity * 0.80;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = quantity * 1.20;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    price = quantity * 1.45;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = quantity * 1.60;
                    Console.WriteLine(price);
                }
            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee")
                {
                    price = quantity * 0.40;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = quantity * 0.70;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = quantity * 1.15;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    price = quantity * 1.30;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = quantity * 1.50;
                    Console.WriteLine(price);
                }
            }
            else if (town == "Varna")
            {
                if (product == "coffee")
                {
                    price = quantity * 0.45;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = quantity * 0.70;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = quantity * 1.10;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    price = quantity * 1.35;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = quantity * 1.55;
                    Console.WriteLine(price);
                }
            }
        }
    }
}
