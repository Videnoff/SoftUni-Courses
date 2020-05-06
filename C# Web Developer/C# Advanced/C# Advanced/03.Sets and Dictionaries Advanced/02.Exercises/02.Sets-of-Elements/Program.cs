using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var commonSet = new HashSet<int>();
            var otherSet = new HashSet<int>();

            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]) + int.Parse(input[1]);

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());

                if (!commonSet.Contains(num))
                {
                    commonSet.Add(num);
                }
                else
                {
                    otherSet.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", otherSet));
        }
    }
}
