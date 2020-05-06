using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            foreach (var element in input)
            {
                if (element % 2 == 0)
                {
                    queue.Enqueue(element);
                }
            }

            foreach (var element in queue)
            {
                if (element % 2 != 0)
                {
                    queue.Dequeue();
                    
                }
            }

            Console.Write(string.Join(", ", queue));

        }
    }
}
