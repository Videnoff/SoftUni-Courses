using System;

namespace TennisEquipment
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double tennisRacketPrice = double.Parse(Console.ReadLine());
            double tennisRacketsCount = double.Parse(Console.ReadLine());
            double sneakers = double.Parse(Console.ReadLine());

            double racketsValue = tennisRacketPrice * tennisRacketsCount;
            double sneakersPrice = sneakers * (tennisRacketPrice / 6.0);
            double totalValue = racketsValue + sneakersPrice;
            double equipment = (totalValue * 20) / 100;
            double totalMoney = totalValue + equipment;
            double jokoMoney = totalMoney / 8.0;
            double sponsorsMoney = totalMoney - jokoMoney;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(jokoMoney)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorsMoney)}");
        }
    }
}
