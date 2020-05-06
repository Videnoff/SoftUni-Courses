using System;
using System.Linq;

namespace _04.Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = ReadStringMatrix(rows, cols);

            string commandInput = Console.ReadLine();

            while (commandInput != "END")
            {
                string[] commandArgs = commandInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];

                if (command != "swap" || commandArgs.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    commandInput = Console.ReadLine();
                    continue;
                }

                int rowOne = int.Parse(commandArgs[1]);
                int colOne = int.Parse(commandArgs[2]);
                int rowTwo = int.Parse(commandArgs[3]);
                int colTwo = int.Parse(commandArgs[4]);

                bool isValidFirstCell = IsValidCell(matrix, rowOne, colOne);
                bool isValidSecondCell = IsValidCell(matrix, rowTwo, colTwo);

                if (isValidFirstCell && isValidSecondCell)
                {
                    string temp = matrix[rowOne, colOne];
                    matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
                    matrix[rowTwo, colTwo] = temp;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                commandInput = Console.ReadLine();
            }
        }

        private static bool IsValidCell(string[,] matrix, in int row, in int col)
        {
            bool isValid = false;

            if (row >= 0 && row < matrix.GetLength(0) 
                         && col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }

            return isValid;
        }

        private static string[,] ReadStringMatrix(in int rows, in int cols)
        {

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions
                        .RemoveEmptyEntries).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
