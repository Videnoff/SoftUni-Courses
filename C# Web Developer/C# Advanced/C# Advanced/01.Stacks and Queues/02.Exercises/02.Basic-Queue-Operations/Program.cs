using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] numbersToEnqueue = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> numbers = new Queue<int>();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            FillQueue(n, numbers, numbersToEnqueue);

            DeleteFromQueue(s, numbers);

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Count > 0 ? numbers.Min() : 0);
            }
        }

        private static void DeleteFromQueue(int s, Queue<int> numbers)
        {
            for (int i = 0; i < s; i++)
            {
                numbers.Dequeue();
            }
        }

        private static void FillQueue(int n, Queue<int> numbers, int[] numbersToEnqueue)
        {
            for (int i = 0; i < n; i++)
            {
                numbers.Enqueue(numbersToEnqueue[i]);
            }
        }
    }
}
