using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Seashell_Treasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            FillBeach(n, out var beach);

            var stolen = 0;
            var collectedSeaShells = new List<char>();

            string input;

            while ((input = Console.ReadLine()) != "Sunset")
            {
                bool isValid = true;

                var splittedInput = input.Split();

                var command = splittedInput[0];
                var rowCommand = int.Parse(splittedInput[1]);
                var colCommand = int.Parse(splittedInput[2]);

                isValid = IsValid(beach, rowCommand, n, colCommand, isValid);

                var playerRow = 0;
                var playerCol = 0;

                if (command == "Collect")
                {
                    if (isValid)
                    {
                        if (char.IsLetter(beach[rowCommand][colCommand]))
                        {
                            collectedSeaShells.Add(beach[rowCommand][colCommand]);
                        }

                        beach[rowCommand][colCommand] = '-';
                    }
                }
                else if (command == "Steal")
                {
                    var direction = splittedInput[3];

                    if (isValid)
                    {
                        if (direction == "up")
                        {
                            for (int row = rowCommand; row >= rowCommand - 3; row--)
                            {
                                if (row >= 0 && row < beach.Length && colCommand >= 0 && colCommand < beach[row].Length && beach[row][colCommand] != '-')
                                {
                                    stolen++;
                                    beach[row][colCommand] = '-';
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int row = rowCommand; row < rowCommand + 3; row++)
                            {
                                if (row >= 0 && row < beach.Length && colCommand >= 0 && colCommand < beach[row].Length && beach[row][colCommand] != '-')
                                {
                                    stolen++;
                                    beach[row][colCommand] = '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int col = colCommand; col >= colCommand - 3; col--)
                            {
                                if (rowCommand >= 0 && rowCommand < beach.Length && col >= 0 && col < beach[rowCommand].Length && beach[col][colCommand] != '-')
                                {
                                    stolen++;
                                    beach[rowCommand][col] = '-';
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int col = colCommand; col <= beach[rowCommand].Length; col++)
                            {
                                if (rowCommand >= 0 && rowCommand < beach.Length && col >= 0 && col < beach[rowCommand].Length && beach[rowCommand][col] != '-')
                                {
                                    stolen++;
                                    beach[rowCommand][col] = '-';
                                }
                            }
                        }
                    }
                }
            }

            PrintBeach(beach);

            

            if (collectedSeaShells.Any())
            {
                Console.WriteLine($"Collected seashells: {collectedSeaShells.Count} -> {string.Join(", ", collectedSeaShells)}");
                Console.WriteLine($"Stolen seashells: {stolen}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collectedSeaShells.Count}");
                Console.WriteLine($"Stolen seashells: { stolen}");
            }

            
        }

        private static void PrintBeach(char[][] beach)
        {
            foreach (var element in beach)
            {
                Console.WriteLine(string.Join(" ", element));
            }
        }

        private static void FillBeach(int n, out char[][] beach)
        {
            beach = new char[n][];

            for (int row = 0; row < beach.Length; row++)
            {
                var seashells = Console.ReadLine().Split().Select(char.Parse).ToArray();
                beach[row] = new char[seashells.Length];

                for (int col = 0; col < beach[row].Length; col++)
                {
                    beach[row][col] = seashells[col];
                }
            }
        }

        private static bool IsValid(char[][] beach, int rowCommand, int n, int colCommand, bool isValid)
        {

            if (rowCommand < 0 || rowCommand >= n || colCommand < 0 || colCommand > beach[rowCommand].Length)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
