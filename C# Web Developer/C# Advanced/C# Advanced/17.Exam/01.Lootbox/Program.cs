using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFirst = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputSecond = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var firstBox = new Queue<int>(inputFirst);
            var secondBox = new Stack<int>(inputSecond);

            var collected = new List<int>();

            while (firstBox.Any() && secondBox.Any())
            {
                var currentFirstItem = firstBox.Peek();
                var currenSecondItem = secondBox.Pop();

                var sum = currentFirstItem + currenSecondItem;

                if (sum % 2 == 0)
                {
                    firstBox.Dequeue();
                    collected.Add(sum);
                }
                else
                {
                    firstBox.Enqueue(currenSecondItem);
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine($"First lootbox is empty");

                if (collected.Sum() >= 100)
                {
                    Console.WriteLine($"Your loot was epic! Value: {collected.Sum()}");
                }
                else
                {
                    Console.WriteLine($"Your loot was poor... Value: {collected.Sum()}");
                }
            }
            else
            {
                Console.WriteLine($"Second lootbox is empty");
                if (collected.Sum() >= 100)
                {
                    Console.WriteLine($"Your loot was epic! Value: {collected.Sum()}");
                }
                else
                {
                    Console.WriteLine($"Your loot was poor... Value: {collected.Sum()}");
                }
            }

        }
    }
}
