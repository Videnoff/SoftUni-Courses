﻿using System;

namespace FruitShop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    price = quantity * 2.50;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "apple")
                {
                    price = quantity * 1.20;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "orange")
                {
                    price = quantity * 0.85;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "grapefruit")
                {
                    price = quantity * 1.45;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "kiwi")
                {
                    price = quantity * 2.70;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "pineapple")
                {
                    price = quantity * 5.50;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "grapes")
                {
                    price = quantity * 3.85;
                    Console.WriteLine($"{price:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana")
                {
                    price = quantity * 2.70;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "apple")
                {
                    price = quantity * 1.25;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "orange")
                {
                    price = quantity * 0.90;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "grapefruit")
                {
                    price = quantity * 1.60;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "kiwi")
                {
                    price = quantity * 3.00;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "pineapple")
                {
                    price = quantity * 5.60;
                    Console.WriteLine($"{price:F2}");
                }
                else if (fruit == "grapes")
                {
                    price = quantity * 4.20;
                    Console.WriteLine($"{price:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
