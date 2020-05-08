using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n][];

            var commands = int.Parse(Console.ReadLine());

            var playerRow = int.MinValue;
            var playerCol = int.MinValue;

            for (int row = 0; row < matrix.Length; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                matrix[row] = new char[currentRow.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (currentRow[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < commands; i++)
            {
                var command = Console.ReadLine();

                matrix[playerRow][playerCol] = '-';

                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                    }
                    else
                    {
                        playerRow = n - 1;
                    }

                    Bonus(matrix, ref playerRow, command, n, ref playerCol);

                    Trap(matrix, ref playerRow, command, n, ref playerCol);

                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        matrix[playerRow][playerCol] = 'f';

                        Console.WriteLine($"Player won!");

                        PrintMatrix(matrix);

                        return;
                    }
                    else
                    {
                        matrix[playerRow][playerCol] = '-';
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < n)
                    {
                        playerRow++;
                    }
                    else
                    {
                        playerRow = 0;
                    }

                    Bonus(matrix, ref playerRow, command, n, ref playerCol);

                    Trap(matrix, ref playerRow, command, n, ref playerCol);

                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        matrix[playerRow][playerCol] = 'f';

                        Console.WriteLine($"Player won!");

                        PrintMatrix(matrix);

                        return;
                    }
                    else
                    {
                        matrix[playerRow][playerCol] = '-';
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        playerCol = n - 1;
                    }

                    Bonus(matrix, ref playerRow, command, n, ref playerCol);

                    Trap(matrix, ref playerRow, command, n, ref playerCol);

                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        matrix[playerRow][playerCol] = 'f';

                        Console.WriteLine($"Player won!");

                        PrintMatrix(matrix);

                        return;
                    }
                    else
                    {
                        matrix[playerRow][playerCol] = '-';
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 < n)
                    {
                        playerCol++;
                    }
                    else
                    {
                        playerCol = 0;
                    }

                    Bonus(matrix, ref playerRow, command, n, ref playerCol);

                    Trap(matrix, ref playerRow, command, n, ref playerCol);

                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        matrix[playerRow][playerCol] = 'f';

                        Console.WriteLine($"Player won!");

                        PrintMatrix(matrix);

                        return;
                    }
                    else
                    {
                        matrix[playerRow][playerCol] = '-';
                    }
                }
            }

            matrix[playerRow][playerCol] = 'f';
            Console.WriteLine($"Player lost!");

            PrintMatrix(matrix);
        }

        private static void Bonus(char[][] matrix, ref int playerRow, string command, int n, ref int playerCol)
        {
            if (matrix[playerRow][playerCol] == 'B')
            {
                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                    }
                    else
                    {
                        playerRow = n - 1;
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < n)
                    {
                        playerRow++;
                    }
                    else
                    {
                        playerRow = 0;
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        playerCol = n - 1;
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 < n)
                    {
                        playerCol++;
                    }
                    else
                    {
                        playerCol = 0;
                    }
                }
            }
        }

        private static void Trap(char[][] matrix, ref int playerRow, string command, int n, ref int playerCol)
        {
            if (matrix[playerRow][playerCol] == 'T')
            {
                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow++;
                    }
                    else
                    {
                        playerRow = n - 1;
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < n)
                    {
                        playerRow--;
                    }
                    else
                    {
                        playerRow = 0;
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol++;
                    }
                    else
                    {
                        playerCol = n - 1;
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 < n)
                    {
                        playerCol--;
                    }
                    else
                    {
                        playerCol = 0;
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}