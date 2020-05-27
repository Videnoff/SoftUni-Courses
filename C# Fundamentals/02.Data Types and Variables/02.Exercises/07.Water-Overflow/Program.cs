using System;

namespace WaterOverflow
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int littersCount = int.Parse(Console.ReadLine());
            int totalLittersInTank = 0;

            int tankCapacity = 255;
            for (int i = 1; i <= littersCount; i++)
            {
                int water = int.Parse(Console.ReadLine());
                if (totalLittersInTank + water <= tankCapacity)
                {
                    totalLittersInTank += water;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine($"{totalLittersInTank}");
        }
    }
}
