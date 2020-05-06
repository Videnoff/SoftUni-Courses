using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var elementsToPush = input[0];
            var elementsToPop = input[1];
            var elementToLook = input[2];

            var stack = new Stack<int>();

            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var element in elements)
            {
                stack.Push(element);
            }

            
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }



            if (stack.Any())
            {
                foreach (var element in stack)
                {
                    if (stack.Contains(elementToLook))
                    {
                        Console.WriteLine("true");
                        break;
                    }
                    else
                    {
                        Console.WriteLine(stack.Min());
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
