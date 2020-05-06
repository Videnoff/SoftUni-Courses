using System;
using System.Linq;

namespace _06.Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var array = new int[n][];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                array[row] = currentRow;
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (array[row].Length == array[row + 1].Length)
                {
                    var currentRow = array[row];
                    var nextRow = array[row + 1];

                    for (int rows = 0; rows < currentRow.Length; rows++)
                    {
                        currentRow[rows] *= 2;
                    }

                    for (int rows = 0; rows < nextRow.Length; rows++)
                    {
                        nextRow[rows] *= 2;
                    }
                }
                else
                {
                    var currentRow = array[row];
                    var nextRow = array[row + 1];

                    for (int rows = 0; rows < currentRow.Length; rows++)
                    {
                        currentRow[rows] /= 2;
                    }

                    for (int rows = 0; rows < nextRow.Length; rows++)
                    {
                        nextRow[rows] /= 2;
                    }
                }
            }

            var input = Console.ReadLine();
            var splittedInput = input.Split();
            var command = splittedInput[0];

            while (command != "End")
            {
                if (command == "Add")
                {
                    var commandRow = int.Parse(splittedInput[1]);
                    var commandCol = int.Parse(splittedInput[2]);
                    var commandValue = int.Parse(splittedInput[3]);

                    if (!(commandRow < 0
                          || commandRow >= array.Length
                          || commandCol < 0
                          || commandCol >= array.Length))
                    {
                        array[commandRow][commandCol] += commandValue;
                    }

                }
                else if (command == "Subtract")
                {
                    var commandRow = int.Parse(splittedInput[1]);
                    var commandCol = int.Parse(splittedInput[2]);
                    var commandValue = int.Parse(splittedInput[3]);

                    if (!(commandRow < 0
                          || commandRow >= array.Length
                          || commandCol < 0
                          || commandCol >= array.Length))
                    {
                        array[commandRow][commandCol] -= commandValue;
                    }
                }

                input = Console.ReadLine();
                splittedInput = input.Split();
                command = splittedInput[0];
            }

            ;

            foreach (var row in array)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
