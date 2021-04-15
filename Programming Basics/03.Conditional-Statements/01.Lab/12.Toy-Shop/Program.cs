using System;

namespace ToyShop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minnionos = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double ordersCount = puzzles + dolls + bears + minnionos + trucks;
            double order = (puzzles * 2.60) + (dolls * 3) + (bears * 4.10) + (minnionos * 8.20) + (trucks * 2);
            double discount = order * 25 / 100;

            if (ordersCount >= 50)
            {
                order -=discount;
            }

            double rent = order * 10 / 100;
            double profit = order - rent;
            double diff = Math.Abs(profit - holidayPrice);

            if (profit >= holidayPrice)
            {
                Console.WriteLine($"Yes! {diff:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {diff:F2} lv needed.");
            }
        }
    }
}
