﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace GaussTrick
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int size = numbers.Count / 2;
            for (int i = 0; i < size; i++)
            {
                int otherSide = numbers[numbers.Count - 1];
                numbers[i] += otherSide;
                numbers.RemoveAt(numbers.Count - 1);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
