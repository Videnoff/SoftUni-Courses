using System;
using System.Linq;
using System.Numerics;

namespace _02.Helens_Abduction
{
    public class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            var field = new char[n][];

            var parisRow = int.MinValue;
            var parisCol = int.MinValue;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                field[row] = new char[currentRow.Length];

                for (int col = 0; col < field[row].Length; col++)
                {
                    field[row][col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }

            field[parisRow][parisCol] = '-';

            while (true)
            {
                var input = Console.ReadLine();
                var splittedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = splittedInput[0];
                var commandRow = int.Parse(splittedInput[1]);
                var commandCol = int.Parse(splittedInput[2]);

                field[commandRow][commandCol] = 'S';

                if (command == "up")
                {
                    if (parisRow - 1 >= 0)
                    {
                        parisRow--;
                    }

                    energy--;
                }
                else if (command == "down")
                {
                    if (parisRow + 1 < n)
                    {
                        parisRow ++;
                    }

                    energy --;
                }
                else if (command == "left")
                {
                    if (parisCol - 1 >= 0)
                    {
                        parisCol --;
                    }

                    energy --;
                }
                else if (command == "right")
                {
                    if (parisCol + 1 < n)
                    {
                        parisCol ++;
                    }

                    energy--;
                }

                if (field[parisRow][parisCol] == 'H')
                {
                    field[parisRow][parisCol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");

                    break;
                }

                if (energy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");

                    break;
                }

                if (field[parisRow][parisCol] == 'S')
                {
                    if (energy - 2 > 0)
                    {
                        energy -= 2;
                        field[parisRow][parisCol] = '-';
                    }
                    else
                    {
                        field[parisRow][parisCol] = 'X';
                        Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                        break;
                    }
                }
            }

            foreach (var row in field)
            {
                Console.WriteLine(row);
            }
        }

        private static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field.Length; col++)
                {
                    Console.Write(field[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}