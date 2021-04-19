using System;

namespace Building
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int floorCount = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = floorCount; i >= 1; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i == floorCount)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{j} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
