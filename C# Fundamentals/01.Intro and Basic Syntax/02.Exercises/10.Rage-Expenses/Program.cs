using System;

namespace RageExpenses
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsets = 0;
            int mouses = 0;
            int keyboards = 0;
            int displays = 0;
            int keyboardCounter = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    headsets++;
                }
                if (i % 3 == 0)
                {
                    mouses++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboards++;
                    keyboardCounter++;
                }
                if (keyboardCounter != 0 && keyboardCounter % 2 == 0)
                {
                    displays++;
                }
                if (keyboardCounter >= 2)
                {
                    keyboardCounter = 0;
                }
            }
            double totalExpenses = headsets * headsetPrice + mouses * mousePrice + keyboards * keyboardPrice + displays * displayPrice;
            Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");
        }
    }
}
