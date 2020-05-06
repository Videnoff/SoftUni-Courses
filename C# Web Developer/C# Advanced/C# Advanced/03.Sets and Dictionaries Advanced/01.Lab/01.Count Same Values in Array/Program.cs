using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            foreach (var currentNumber in input)
            {
                if (!dictionary.ContainsKey(currentNumber))
                {
                    dictionary.Add(currentNumber, 0);
                }

                dictionary[currentNumber] += 1;
            }

            foreach (var (key, value) in dictionary)
            {
                Console.WriteLine($"{key} - {value} times");
            }
        }
    }
}
