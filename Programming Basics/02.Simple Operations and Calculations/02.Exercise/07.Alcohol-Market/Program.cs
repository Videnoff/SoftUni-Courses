using System;

namespace AlcoholMarket
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beerLitters = double.Parse(Console.ReadLine());
            double wineLitters = double.Parse(Console.ReadLine());
            double rakijaLitters = double.Parse(Console.ReadLine());
            double whiskeyLitters = double.Parse(Console.ReadLine());

            double rakijaPrice = whiskeyPrice / 2;
            double winePrice = (rakijaPrice - (rakijaPrice * 40) / 100);
            double beerPrice = (rakijaPrice - (rakijaPrice * 80) / 100);

            double sum = (whiskeyLitters * whiskeyPrice) + (beerLitters * beerPrice) + (wineLitters * winePrice) + (rakijaLitters * rakijaPrice);
            Console.WriteLine($"{sum:F2}");
        }
    }
}
