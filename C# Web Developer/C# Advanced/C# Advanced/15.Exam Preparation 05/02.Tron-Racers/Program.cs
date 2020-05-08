using System;

namespace _02.Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var firstPlayerRow = int.MinValue;
            var firstPlayerCol = int.MinValue;

            var secondPlayerRow = int.MinValue;
            var secondPlayerCol = int.MinValue;

            var matrix = new char[size][];

            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                matrix[row] = new char[currentRow.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (currentRow[col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }

                    if (currentRow[col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split();

                var firstCommand = command[0];
                var secondCommand = command[1];

                if (firstCommand == "up")
                {
                    if (firstPlayerRow - 1 >= 0)
                    {
                        firstPlayerRow--;
                    }
                    else
                    {
                        firstPlayerRow = size - 1;
                    }


                    if (matrix[firstPlayerRow][firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow][firstPlayerCol] = 'x';

                        PrintMatrix(matrix);

                        break;
                    }
                    else
                    {
                        matrix[firstPlayerRow][firstPlayerCol] = 'f';
                    }
                }
                else if (firstCommand == "down")
                {
                    if (firstPlayerRow + 1 < size)
                    {
                        firstPlayerRow++;
                    }
                    else
                    {
                        firstPlayerRow = 0;
                    }

                    if (matrix[firstPlayerRow][firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow][firstPlayerCol] = 'x';

                        PrintMatrix(matrix);

                        break;
                    }
                    else
                    {
                        matrix[firstPlayerRow][firstPlayerCol] = 'f';
                    }
                }
                else if (firstCommand == "left")
                {
                    if (firstPlayerCol - 1 >= 0)
                    {
                        firstPlayerCol--;
                    }
                    else
                    {
                        firstPlayerCol = size - 1;
                    }

                    if (matrix[firstPlayerRow][firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow][firstPlayerCol] = 'x';

                        PrintMatrix(matrix);

                        break;
                    }
                    else
                    {
                        matrix[firstPlayerRow][firstPlayerCol] = 'f';
                    }

                }
                else if (firstCommand == "right")
                {
                    if (firstPlayerCol + 1 < size)
                    {
                        firstPlayerCol++;
                    }
                    else
                    {
                        firstPlayerCol = 0;
                    }

                    if (matrix[firstPlayerRow][firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow][firstPlayerCol] = 'x';

                        PrintMatrix(matrix);

                        break;
                    }
                    else
                    {
                        matrix[firstPlayerRow][firstPlayerCol] = 'f';
                    }
                }


                if (secondCommand == "up")
                {
                    if (secondPlayerRow - 1 >= 0)
                    {
                        secondPlayerRow--;
                    }
                    else
                    {
                        secondPlayerRow = size - 1;
                    }

                    if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
                    {
                        matrix[secondPlayerRow][secondPlayerCol] = 'x';

                        PrintMatrix(matrix);

                        break;
                    }

                    matrix[secondPlayerRow][secondPlayerCol] = 's';
                }
                else if (secondCommand == "down")
                {
                    if (secondPlayerRow + 1 < size)
                    {
                        secondPlayerRow++;
                    }
                    else
                    {
                        secondPlayerRow = 0;
                    }

                    if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
                    {
                        matrix[secondPlayerRow][secondPlayerCol] = 'x';

                        PrintMatrix(matrix);

                        break;
                    }

                    matrix[secondPlayerRow][secondPlayerCol] = 's';
                }
                else if (secondCommand == "left")
                {
                    if (secondPlayerCol - 1 >= 0)
                    {
                        secondPlayerCol--;
                    }
                    else
                    {
                        secondPlayerCol = size - 1;
                    }

                    if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
                    {
                        matrix[secondPlayerRow][secondPlayerCol] = 'x';

                        PrintMatrix(matrix);

                        break;
                    }

                    matrix[secondPlayerRow][secondPlayerCol] = 's';
                }
                else if (secondCommand == "right")
                {
                    if (secondPlayerCol + 1 < size)
                    {
                        secondPlayerCol++;
                    }
                    else
                    {
                        secondPlayerCol = 0;
                    }

                    if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
                    {
                        matrix[secondPlayerRow][secondPlayerCol] = 'x';

                        PrintMatrix(matrix);

                        break;
                    }

                    matrix[secondPlayerRow][secondPlayerCol] = 's';
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