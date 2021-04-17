using System;

namespace BachelorParty
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int singerPrice = int.Parse(Console.ReadLine());
            double couvert = 0.0;
            double totalMoney = 0.0;
            int guestsCount = 0;
            while (true)
            {
                string stop = Console.ReadLine();
                if (stop == "The restaurant is full")
                {
                    break;
                }

                int guests = int.Parse(stop);

                if (guests >= 5)
                {
                    couvert = guests * 70;
                }
                else
                {
                    couvert = guests * 100;
                }

                totalMoney += couvert;
                guestsCount += guests;
            }


            if (totalMoney >= singerPrice)
            {
                double sumLeft = totalMoney - singerPrice;
                Console.WriteLine($"You have {guestsCount} guests and {sumLeft} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {guestsCount} guests and {totalMoney} leva income, but no singer.");
            }
        }
    }
}
