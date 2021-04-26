using System;

namespace FishingBoat
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());
            double boatRent = 0.0;
            double discount = 0.0;
            double evenBonus = 0.0;


            if (season == "Spring")
            {
                boatRent = 3000;
                if (fishers <= 6)
                {
                    discount = boatRent * 10 / 100;
                }
                else if (fishers > 7 && fishers <= 11)
                {
                    discount = boatRent * 15 / 100;
                }
                else
                {
                    discount = boatRent * 25 / 100;
                }
            }
            else if (season == "Summer")
            {
                boatRent = 4200;
                if (fishers <= 6)
                {
                    discount = boatRent * 10 / 100;
                }
                else if (fishers > 7 && fishers <= 11)
                {
                    discount = boatRent * 15 / 100;
                }
                else
                {
                    discount = boatRent * 25 / 100;
                }
            }
            else if (season == "Autumn")
            {
                boatRent = 4200;
                if (fishers <= 6)
                {
                    discount = boatRent * 10 / 100;
                }
                else if (fishers > 7 && fishers <= 11)
                {
                    discount = boatRent * 15 / 100;
                }
                else
                {
                    discount = boatRent * 25 / 100;
                }
            }
            else if (season == "Winter")
            {
                boatRent = 2600;
                if (fishers <= 6)
                {
                    discount = boatRent * 10 / 100;
                }
                else if (fishers > 7 && fishers <= 11)
                {
                    discount = boatRent * 15 / 100;
                }
                else
                {
                    discount = boatRent * 25 / 100;
                }
            }

            double moneyEnough = boatRent - discount - evenBonus;

            if (season != "Autumn" && fishers % 2 == 0)
            {
                evenBonus = (boatRent - discount) * 5 / 100;
                moneyEnough = boatRent - discount - evenBonus;
            }
            else
            {
                moneyEnough = boatRent - discount;
            }


            double diff = budget - moneyEnough;
            double plusDiff = Math.Abs(diff);

            if (diff >= 0)
            {
                Console.WriteLine($"Yes! You have {diff:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {plusDiff:F2} leva.");
            }
        }
    }
}
