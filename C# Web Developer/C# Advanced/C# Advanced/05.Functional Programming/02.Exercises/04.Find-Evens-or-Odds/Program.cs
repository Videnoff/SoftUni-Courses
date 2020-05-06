using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string query = Console.ReadLine();

            Predicate<int> predicate = GetPredicate(query);

            List<int> res = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    res.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", res));
        }

        static Predicate<int> GetPredicate(string query)
        {
            if (query == "odd")
            {
                return new Predicate<int>((n) => n % 2 != 0);
            }
            else
            {
                return new Predicate<int>((n) => n % 2 == 0);
            }
        }
    }
}
