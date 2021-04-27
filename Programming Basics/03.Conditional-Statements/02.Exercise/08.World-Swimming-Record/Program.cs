using System;

namespace WorldSwimmingRecord
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double recordTime = double.Parse(Console.ReadLine());
            double recordDistance = double.Parse(Console.ReadLine());
            double timeFor1meter = double.Parse(Console.ReadLine());

            double ivanDistance = recordDistance * timeFor1meter;
            double waterResistance = Math.Floor(recordDistance / 15) * 12.5;

            double ivanTime = ivanDistance + waterResistance;
            double diff = Math.Abs(recordTime - ivanTime);

            if (ivanTime < recordTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {diff:F2} seconds slower.");
            }
        }
    }
}
