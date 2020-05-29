using System;
using System.Linq;

namespace RecursiveFibonacci
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            int result = 0;

            int[] array = new int[counter];

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    array[i] = 1;
                }
                else if (i == 2)
                {
                    array[i] = 2;
                }
                else
                {
                    array[i] = array[i - 1] + array[i - 2];
                }
                result = array[array.Length - 1];
            }
            Console.WriteLine(result);
        }
    }
}
