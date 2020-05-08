using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLeft = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputRight = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var leftSocks = new Stack<int>(inputLeft);
            var rightSocks = new List<int>(inputRight);

            var pairs = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                var currentLeftSock = leftSocks.Pop();
                var currentRightSock = rightSocks[0];

                if (currentLeftSock > currentRightSock)
                {
                    pairs.Add(currentLeftSock + currentRightSock);
                    rightSocks.Remove(currentRightSock);
                }
                else if (currentLeftSock < currentRightSock)
                {
                    //rightSocks.Remove(currentRightSock);
                }
                else
                {
                    rightSocks.Remove(currentRightSock);
                    leftSocks.Push(currentLeftSock + 1);
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
