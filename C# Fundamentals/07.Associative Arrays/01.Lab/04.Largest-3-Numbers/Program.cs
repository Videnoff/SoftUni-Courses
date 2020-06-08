using System;
using System.Linq;
using System.Collections.Generic;

namespace Largest3Numbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // First Option:

            //Console.ReadLine().Split().Select(int.Parse).OrderByDescending(n => n)
            //.Take(3).ToList().ForEach(Console.WriteLine);

            // Second Option:

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(n => n)
                                   .ToArray();

            int count = numbers.Length >= 3 ? 3 : numbers.Length;

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

        }
    }
}
