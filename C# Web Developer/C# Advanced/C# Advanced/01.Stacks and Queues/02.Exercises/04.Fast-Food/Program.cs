using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            var orderQuantity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(orderQuantity);

            //foreach (var element in orderQuantity)
            //{
            //    queue.Enqueue(element);
            //}

            Console.WriteLine(orderQuantity.Max());

            while (queue.Count > 0)
            {
                var currentOrder = queue.Peek();

                    if (foodQuantity >= currentOrder)
                    {
                        foodQuantity -= currentOrder;
                        queue.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                        break;
                    }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine($"Orders complete");
            }
        }
    }
}
