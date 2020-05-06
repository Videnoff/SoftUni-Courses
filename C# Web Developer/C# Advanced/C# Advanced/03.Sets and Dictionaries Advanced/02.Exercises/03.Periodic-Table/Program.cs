using System;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var mySet = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var splittedInput = input.Split();

                for (int j = 0; j < splittedInput.Length; j++)
                {
                    if (!mySet.Contains(splittedInput[j]))
                    {
                        mySet.Add(splittedInput[j]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", mySet));
        }
    }
}
