using System;
using System.Linq;

namespace _01.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            var diagonalOne = 0;
            var diagonalTwo = 0;

            for (int row = 0; row < n; row++)
            {
                diagonalOne += matrix[row, row];
                diagonalTwo += matrix[row, n - row - 1];
            }
        }
    }
}
