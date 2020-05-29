using System;

namespace PascalTriangle
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            Console.WriteLine(1);

            if (numberOfRows == 1)
            {
                return;
            }

            int[] initialArray = new int[] { 1, 1 };
            Console.WriteLine(string.Join(" ", initialArray));

            if (numberOfRows == 2)
            {
                return;
            }
            else
            {
                for (int i = 0; i < initialArray.Length + 1; i++)
                {
                    int[] arr = new int[initialArray.Length + 1];
                    arr[0] = 1;
                    arr[arr.Length - 1] = 1;

                    for (int j = 1; j < arr.Length - 1; j++)
                    {
                        arr[j] = initialArray[j - 1] + initialArray[j];
                    }
                    Console.WriteLine(string.Join(" ", arr));

                    initialArray = arr;
                    if (initialArray.Length == numberOfRows)
                    {
                        break;
                    }
                }
            }
        }
    }
}
