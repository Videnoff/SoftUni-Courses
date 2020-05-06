using System;
using System.Linq;

namespace _06.Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             4
             1 2 3 4 5
             6 7 8
             9 10 11 12
             13 14
             Add 0 3 10
             Subtract 1 1 10
             Add 3 2 20
             End
             */

            int rows = int.Parse(Console.ReadLine());

            int[][] array = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                array[row] = currentRow;
            }

            while (true)
            {
                string command = Console.ReadLine().ToLower();

                if (command == "end")
                {
                    /*
                     Print with LINQ:
                      Console.WriteLine(string.Join(Environment.NewLine, array.Select(currentRow => string.Join(" ", currentRow))));
                     */

                    foreach (var currentRow in array)
                    {
                        Console.WriteLine(string.Join(" ", currentRow));
                    }

                    break;
                }

                string[] commandParts = command.Split();
                int row = int.Parse(commandParts[1]);
                int col = int.Parse(commandParts[2]);
                int value = int.Parse(commandParts[3]);

                if (row < 0 
                    || row >= rows
                    || col < 0
                    || col >= array[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else if (commandParts[0] == "add")
                {
                    array[row][col] += value;
                }
                else if (commandParts[0] == "subtract")
                {
                    array[row][col] -= value;
                }
            }
        }
    }
}
