using System;
using System.Linq;

namespace _01.Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();    

            var result = Sum(arr);

            Console.WriteLine(result);
        }

        public static int Sum(int[] arr, int index = 0)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + Sum(arr, index + 1);
        }
    }
}
