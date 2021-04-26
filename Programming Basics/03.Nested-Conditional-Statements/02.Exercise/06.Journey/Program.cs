using System;

namespace Journey
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double moneySpent = 0;
            string destination = "";
            string holidayType = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    holidayType = "Camp";
                    moneySpent = budget * 30 / 100;
                }
                else if (season == "winter")
                {
                    holidayType = "Hotel";
                    moneySpent = budget * 70 / 100;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    holidayType = "Camp";
                    moneySpent = budget * 40 / 100;
                }
                else if (season == "winter")
                {
                    holidayType = "Hotel";
                    moneySpent = budget * 80 / 100;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                holidayType = "Hotel";
                moneySpent = budget * 90 / 100;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{holidayType} - {moneySpent:F2}");
        }
    }
}
