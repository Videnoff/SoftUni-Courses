using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var snake = Console.ReadLine().ToCharArray();

            var rows = size[0];
            var cols = size[1];

            var matrix = new char[rows][];
            var snakeQueue = new Queue<char>(snake);

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];

                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        char charToAdd = snakeQueue.Dequeue();
                        matrix[row][col] = charToAdd;
                        snakeQueue.Enqueue(charToAdd);


                    }
                }
                else
                {
                    for (int coll = cols - 1; coll >= 0; coll--)
                    {
                        char charToAdd = snakeQueue.Dequeue();
                        matrix[row][coll] = charToAdd;
                        snakeQueue.Enqueue(charToAdd);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
        }
    }
}
