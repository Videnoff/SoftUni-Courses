using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var queue = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    foreach (var name in queue)
                    {
                        Console.WriteLine(name);
                    }

                    queue.Clear();
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
