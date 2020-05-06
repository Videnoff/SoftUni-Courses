using System;
using System.Linq;

namespace _03.Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] += currentRow[col];
                }
            }

            var diagonalSum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row == col)
                    {
                        diagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
