using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            while (true)
            {
                string[] commmand = Console.ReadLine().ToLower().Split();

                if (commmand[0] == "add")
                {
                    stack.Push(int.Parse(commmand[1]));
                    stack.Push(int.Parse(commmand[2]));
                }
                else if (commmand[0] == "remove")
                {
                    int totalElementsToRemove = int.Parse(commmand[1]);

                    if (stack.Count >= totalElementsToRemove)
                    {
                        for (int i = 0; i < totalElementsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
