using System;
using System.Linq;

namespace EqualArrays
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            bool findDiff = false;
            for (int i = 0; i < firstArr.Length; i++)
            {
                if (firstArr[i] != secondArr[i])
                {
                    findDiff = true;
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
                else
                {
                    sum += firstArr[i];
                }
            }
            if (findDiff != true)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
