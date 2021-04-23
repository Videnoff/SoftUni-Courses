using System;

namespace Histogram
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p4 = 0.0;
            double p5 = 0.0;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (num < 200)
                {
                    p1++;
                }
                else if (num >= 200 && num <= 399)
                {
                    p2++;
                }
                else if (num >= 400 && num <= 599)
                {
                    p3++;
                }
                else if (num >= 600 && num <= 799)
                {
                    p4++;
                }
                else if (num >= 800)
                {
                    p5++;
                }
            }

            double p1Percent = (p1 / n) * 100;
            double p2Percent = (p2 / n) * 100;
            double p3Percent = (p3 / n) * 100;
            double p4Percent = (p4 / n) * 100;
            double p5Percent = (p5 / n) * 100;

            Console.WriteLine($"{p1Percent:F2}%");
            Console.WriteLine($"{p2Percent:F2}%");
            Console.WriteLine($"{p3Percent:F2}%");
            Console.WriteLine($"{p4Percent:F2}%");
            Console.WriteLine($"{p5Percent:F2}%");
        }
    }
}
