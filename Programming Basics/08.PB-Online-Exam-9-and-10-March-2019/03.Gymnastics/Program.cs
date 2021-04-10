using System;

namespace Gymnastics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string appliance = Console.ReadLine();
            double difficulty = 0.0;
            double performance = 0.0;
            double totalPoints = 0.0;
            double percent = 0.0;

            if (country == "Russia")
            {
                if (appliance == "ribbon")
                {
                    difficulty = 9.100;
                    performance = 9.400;
                }
                else if (appliance == "hoop")
                {
                    difficulty = 9.300;
                    performance = 9.800;
                }
                else if (appliance == "rope")
                {
                    difficulty = 9.600;
                    performance = 9.000;
                }
            }
            else if (country == "Bulgaria")
            {
                if (appliance == "ribbon")
                {
                    difficulty = 9.600;
                    performance = 9.400;
                }
                else if (appliance == "hoop")
                {
                    difficulty = 9.550;
                    performance = 9.750;
                }
                else if (appliance == "rope")
                {
                    difficulty = 9.500;
                    performance = 9.400;
                }
            }
            else if (country == "Italy")
            {
                if (appliance == "ribbon")
                {
                    difficulty = 9.200;
                    performance = 9.500;
                }
                else if (appliance == "hoop")
                {
                    difficulty = 9.450;
                    performance = 9.350;
                }
                else if (appliance == "rope")
                {
                    difficulty = 9.700;
                    performance = 9.150;
                }
            }
            totalPoints = difficulty + performance;
            double diff = 20 - totalPoints;
            percent = (diff / 20) * 100;

            Console.WriteLine($"The team of {country} get {totalPoints:F3} on {appliance}.");
            Console.WriteLine($"{percent:F2}%");
        }
    }
}
