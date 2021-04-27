using System;

namespace Timeplus15Minutes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int startSum = (hour * 60) + minutes;
            int endSum = startSum + 15;
            int timePlus15 = endSum / 60;
            int minsPlus15 = endSum % 60;

            if (timePlus15 >= 24)
            {
                timePlus15 -= 24;   
            }

            Console.WriteLine($"{timePlus15}:{minsPlus15:D2}");
        }
    }
}
