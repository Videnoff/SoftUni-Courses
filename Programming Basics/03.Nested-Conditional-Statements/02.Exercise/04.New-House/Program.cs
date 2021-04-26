using System;

namespace NewHouse
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double discount = 0.0;
            double flowerPrice = 0.0;
            double totalPrice = 0.0;

            if (flowerType == "Roses")
            {
                flowerPrice = flowerCount * 5.00;
                if (flowerCount > 80)
                {
                    discount = (flowerPrice * 10) / 100;
                    totalPrice = flowerPrice - discount;
                }
                else
                {
                    totalPrice = flowerPrice;
                }
            }
            else if (flowerType == "Dahlias")
            {
                flowerPrice = flowerCount * 3.80;
                if (flowerCount > 90)
                {
                    discount = (flowerPrice * 15) / 100;
                    totalPrice = flowerPrice - discount;
                }
                else
                {
                    totalPrice = flowerPrice;
                }
            }
            else if (flowerType == "Tulips")
            {
                flowerPrice = flowerCount * 2.80;
                if (flowerCount > 80)
                {
                    discount = (flowerPrice * 15) / 100;
                    totalPrice = flowerPrice - discount;
                }
                else
                {
                    totalPrice = flowerPrice;
                }
            }
            else if (flowerType == "Narcissus")
            {
                flowerPrice = flowerCount * 3.00;
                if (flowerCount < 120)
                {
                    discount = (flowerPrice * 15) / 100;
                    totalPrice = flowerPrice + discount;
                }
                else
                {
                    totalPrice = flowerPrice;
                }
            }
            else if (flowerType == "Gladiolus")
            {
                flowerPrice = flowerCount * 2.50;
                if (flowerCount < 80)
                {
                    discount = (flowerPrice * 20) / 100;
                    totalPrice = flowerPrice + discount;
                }
                else
                {
                    totalPrice = flowerPrice;
                }
            }

            double diff = (budget - totalPrice);
            double plusDiff = Math.Abs(budget - totalPrice);

            if (diff >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {diff:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {plusDiff:F2} leva more.");
            }
        }
    }
}
