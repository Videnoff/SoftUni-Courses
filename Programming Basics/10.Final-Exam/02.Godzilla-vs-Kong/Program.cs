using System;

namespace GodzillavsKong
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double statists = double.Parse(Console.ReadLine());
            double statOutfitPrice = double.Parse(Console.ReadLine());

            double decor = (budget * 10) / 100;
            double statMoney = statists * statOutfitPrice;

            double sum = decor + statMoney;
            double discount = 0.0;
            if (statists > 150)
            {
                discount = (statMoney * 10) / 100;
                sum = decor + (statMoney - discount);
            }
            else
            {
                sum = decor + statMoney;
            }
            double diff = Math.Abs(budget - sum);
            if (budget >= sum)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {diff:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {diff:F2} leva more.");
            }
        }
    }
}
