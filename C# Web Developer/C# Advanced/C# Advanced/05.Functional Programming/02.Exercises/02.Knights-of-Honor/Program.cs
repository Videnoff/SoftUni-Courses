using System;
using System.Linq;

namespace _02.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(" ",
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(new Action<string>(name =>
                {
                    Console.WriteLine("Sir " + name);
                }));
        }
    }
}
