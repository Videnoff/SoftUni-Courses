using System;

namespace Skeleton
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double mins = double.Parse(Console.ReadLine());
            double secs = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double secsFor100Met = double.Parse(Console.ReadLine());

            double contSecs = mins * 60 + secs;
            double slowing = length / 120;
            double totalSlowing = slowing * 2.5;
            double marinTime = (length / 100) * secsFor100Met - totalSlowing;
            double diff = Math.Abs(contSecs - marinTime);

            if (contSecs > marinTime)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {marinTime:F3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {diff:F3} second slower.");
            }

        }
    }
}
