using System;
using System.Linq;

namespace _01.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ParseArrayFromConsole();

            int rows = dimensions[0];
            int cols = dimensions[1];

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = ParseArrayFromConsole();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            long sum = 0;

            foreach (var element in matrix)
            {
                sum += element;
            }

            Console.WriteLine(sum);
        }

        static int[] ParseArrayFromConsole()
            => Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
    }
}
