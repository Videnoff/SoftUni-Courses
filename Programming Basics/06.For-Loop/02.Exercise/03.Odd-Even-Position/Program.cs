﻿using System;

namespace OddEvenPosition
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0.0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                }
                else
                {
                    oddSum += num;
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:F2},");
            if (oddMin != double.MaxValue)
            {
                Console.WriteLine($"OddMin={oddMin:F2},");
            }
            else
            {
                Console.WriteLine("OddMin=No,");
            }
            if (oddMax != double.MinValue)
            {
                Console.WriteLine($"OddMax={oddMax:F2},");
            }
            else
            {
                Console.WriteLine("OddMax=No,");
            }
            Console.WriteLine($"EvenSum={evenSum:F2},");
            if (evenMin != double.MaxValue)
            {
                Console.WriteLine($"EvenMin={evenMin:F2},");
            }
            else
            {
                Console.WriteLine("EvenMin=No,");
            }
            if (evenMax != double.MinValue)
            {
                Console.WriteLine($"EvenMax={evenMax:F2}");
            }
            else
            {
                Console.WriteLine("EvenMax=No");
            }
        }
    }
}
