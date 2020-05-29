using System;
using System.Linq;

namespace FoldandSum
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] left = new int[input.Length / 4];
            int[] middle = new int[input.Length / 2];
            int[] right = new int[input.Length / 4];

            for (int i = 0; i < input.Length / 4; i++)
            {
                left[i] = input[i];
                right[i] = input[i + 3 * (input.Length) / 4];
            }
            left = left.Reverse().ToArray();
            right = right.Reverse().ToArray();

            for (int i = 0; i < middle.Length; i++)
            {
                middle[i] = input[i + input.Length / 4];
            }

            for (int i = 0; i < middle.Length; i++)
            {
                if (i < middle.Length / 2)
                {
                    middle[i] = middle[i] + left[i];
                }
                else
                {
                    middle[i] = middle[i] + right[i - middle.Length / 2];
                }
            }
            Console.WriteLine(string.Join(" ", middle));
        }
    }
}
