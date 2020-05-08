using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var table = new string[size][];

            for (int row = 0; row < table.Length; row++)
            {
                var currentRow = Console.ReadLine().Split(", ");
                table[row] = currentRow;

                for (int col = 0; col < table[row].Length; col++)
                {
                    table[row][col] = currentRow[col];
                }
            }

            var input = Console.ReadLine().Split();

            var command = input[0];
            var part = input[1];

            var headerIndex = Array.IndexOf(table[0], part);

            if (command == "hide")
            {
                for (int row = 0; row < table.Length; row++)
                {
                    List<string> lineToPrint = new List<string>(table[row]);

                    lineToPrint.RemoveAt(headerIndex);

                    Console.WriteLine(string.Join(" | ", lineToPrint));

                    table[row] = lineToPrint.ToArray();
                }
            }
            else if (command == "sort")
            {
                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                table = table.OrderBy(x => x[headerIndex]).ToArray();

                foreach (var row in table)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (command == "filter")
            {
                var secondPart = input[2];

                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                for (int row = 0; row < table.Length; row++)
                {
                    if (table[row][headerIndex] == secondPart)
                    {
                        Console.WriteLine(string.Join(" | ", table[row]));
                    }
                }
            }
        }
    }
}
