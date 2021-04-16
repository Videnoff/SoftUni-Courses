using System;

namespace OscarsWeekinCinema
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            string hallType = Console.ReadLine();
            int ticketsCount = int.Parse(Console.ReadLine());
            double profit = 0.0;

            if (filmName == "A Star Is Born")
            {
                if (hallType == "normal")
                {
                    profit = ticketsCount * 7.50;
                }
                else if (hallType == "luxury")
                {
                    profit = ticketsCount * 10.50;
                }
                else if (hallType == "ultra luxury")
                {
                    profit = ticketsCount * 13.50;
                }
            }
            else if (filmName == "Bohemian Rhapsody")
            {
                if (hallType == "normal")
                {
                    profit = ticketsCount * 7.35;
                }
                else if (hallType == "luxury")
                {
                    profit = ticketsCount * 9.45;
                }
                else if (hallType == "ultra luxury")
                {
                    profit = ticketsCount * 12.75;
                }
            }
            else if (filmName == "Green Book")
            {
                if (hallType == "normal")
                {
                    profit = ticketsCount * 8.15;
                }
                else if (hallType == "luxury")
                {
                    profit = ticketsCount * 10.25;
                }
                else if (hallType == "ultra luxury")
                {
                    profit = ticketsCount * 13.25;
                }
            }
            else if (filmName == "The Favourite")
            {
                if (hallType == "normal")
                {
                    profit = ticketsCount * 8.75;
                }
                else if (hallType == "luxury")
                {
                    profit = ticketsCount * 11.55;
                }
                else if (hallType == "ultra luxury")
                {
                    profit = ticketsCount * 13.95;
                }
            }

            Console.WriteLine($"{filmName} -> {profit:F2} lv.");
        }
    }
}
