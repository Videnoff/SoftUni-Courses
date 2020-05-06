using System;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(", ")
                .Select(n => int.Parse(n))
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();

            string result = string.Join(", ", numbers);

            Console.WriteLine(result);
        }
    }
}
