using System;
using System.Linq;
using System.Threading;

namespace _02.Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
               3 4
               A B B D
               E B B B
               I J B B
               
             */

            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new char[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int counter = 0;

            for (int row = 0; row <= sizes[0] - 2; row++)
            {
                for (int col = 0; col <= sizes[1] - 2; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
