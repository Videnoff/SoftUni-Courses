using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(input);

            var sum = 0;
            int racks = 1;


            while (stack.Any())
            {

                if (rackCapacity >= sum + stack.Peek())
                {
                    sum += stack.Pop();
                }
                else
                {
                    racks++;
                    sum = 0;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
