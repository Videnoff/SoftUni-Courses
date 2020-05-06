using System;
using System.Linq;

namespace _03.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              4 5
              1 5 5 2 4
              2 1 4 14 3
              3 7 11 2 8
              4 8 12 16 4
            */

            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rows = sizes[0];
            var cols = sizes[1];

            int bestSum = 0;
            int bestRowIndex = 0;
            int bestColIndex = 0;

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var rowOneSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    var rowTwoSum = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    var rowThreeSum = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    var currentSum = rowOneSum + rowTwoSum + rowThreeSum;

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestRowIndex = row;
                        bestColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int i = bestRowIndex; i <= bestRowIndex + 2; i++)
            {
                for (int j = bestColIndex; j <= bestColIndex + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
