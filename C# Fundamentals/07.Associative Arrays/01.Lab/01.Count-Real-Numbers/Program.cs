﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace CountRealNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var count = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!count.ContainsKey(number))
                {
                    count[number] = 1;
                }
                else
                {
                    count[number]++;
                }
            }

            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
