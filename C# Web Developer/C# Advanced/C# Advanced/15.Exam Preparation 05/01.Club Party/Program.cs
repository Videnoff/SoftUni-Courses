using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split();

            var stack = new Stack<string>(input);

            var halls = new Queue<string>();

            var reservations = new List<int>();

            var currentCapacity = 0;

            while (stack.Any())
            {
                var currentElement = stack.Pop();

                bool isNumber = int.TryParse(currentElement, out int parsedResult);

                if (!isNumber)
                {
                    halls.Enqueue(currentElement);
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (parsedResult + currentCapacity > capacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", reservations)}");
                        reservations.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Any())
                    {
                        reservations.Add(parsedResult);
                        currentCapacity += parsedResult;
                    }
                }
            }
        }
    }
}
