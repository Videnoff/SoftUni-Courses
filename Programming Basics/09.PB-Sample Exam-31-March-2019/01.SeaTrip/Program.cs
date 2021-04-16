using System;

namespace Problem01SeaTrip
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double meatMoney = double.Parse(Console.ReadLine());
            double souveniresMoney = double.Parse(Console.ReadLine());
            double hotelMoney = double.Parse(Console.ReadLine());

            double fuelMoney = (420.0 / 100.0) * 7.0;
            double totalFuel = fuelMoney * 1.85;

            double totaFoodMoney = 3 * meatMoney;

            double spentMoneysouv = 3 * souveniresMoney;
            double discountF = (hotelMoney * 10) / 100;
            double discountS = (hotelMoney * 15) / 100;
            double discountT = (hotelMoney * 20) / 100;
            double totalHotel = (3 * hotelMoney) - discountF - discountS - discountT;

            double totalMoney = totalFuel + totalHotel + spentMoneysouv + totaFoodMoney;
            Console.WriteLine($"Money needed: {totalMoney:F2}");
        }
    }
}
