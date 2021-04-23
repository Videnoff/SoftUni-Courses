using System;

namespace DivideWithoutRemainder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    p1++;
                }
                if (num % 3 == 0)
                {
                    p2++;
                }
                if (num % 4 == 0)
                {
                    p3++;
                }
            }

            Console.WriteLine($"{(p1 / n) * 100:F2}%");
            Console.WriteLine($"{(p2 / n) * 100:F2}%");
            Console.WriteLine($"{(p3 / n) * 100:F2}%");
        }
    }
}
