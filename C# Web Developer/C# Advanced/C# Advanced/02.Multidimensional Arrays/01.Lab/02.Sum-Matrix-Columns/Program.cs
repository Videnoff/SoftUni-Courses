using System;
using System.Linq;

namespace _02.Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *
             
            int[] dimensions = ParseArrayFromConsole(' ', ',');

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = ParseArrayFromConsole(' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumOfCurrentColumn = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumOfCurrentColumn += matrix[row, col];
                }

                Console.WriteLine(sumOfCurrentColumn);
            }

            */

            var size = ParseArrayFromConsole(',');

            int rowss = size[0];
            int colss = size[1];

            int[,] matrixx = new int[rowss, colss];

            for (int row = 0; row < rowss; row++)
            {
                var currentRoww = ParseArrayFromConsole();

                for (int col = 0; col < colss; col++)
                {
                    matrixx[row, col] = currentRoww[col];
                }
            }


            for (int col = 0; col < matrixx.GetLength(1); col++)
            {
                int sumOfCurrentCol = 0;
                for (int row = 0; row < matrixx.GetLength(0); row++)
                {
                    sumOfCurrentCol += matrixx[row, col];
                }

                Console.WriteLine(sumOfCurrentCol);
            }
        }

        static int[] ParseArrayFromConsole(params char[] splitSymbols) 
            => Console.ReadLine().Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
    }
}
