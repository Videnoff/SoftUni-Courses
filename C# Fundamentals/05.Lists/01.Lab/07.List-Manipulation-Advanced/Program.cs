using System;
using System.Linq;
using System.Collections.Generic;

namespace ListManipulationAdvanced
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> evens = new List<int>();
            List<int> odds = new List<int>();
            List<int> filterSmaller = new List<int>();
            List<int> filterBigger = new List<int>();
            List<int> filterSmallerOrEqual = new List<int>();
            List<int> filterBiggerOrEqual = new List<int>();
            int count = 0;
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splittedInput = input.Split();
                string command = splittedInput[0];


                if (command == "Add")
                {
                    int numberToAdd = int.Parse(splittedInput[1]);
                    numbers.Add(numberToAdd);
                }
                else if (command == "Remove")
                {
                    int numberToRemove = int.Parse(splittedInput[1]);
                    numbers.Remove(numberToRemove);
                }
                else if (command == "RemoveAt")
                {
                    int indexToRemove = int.Parse(splittedInput[1]);
                    numbers.RemoveAt(indexToRemove);
                }
                else if (command == "Insert")
                {
                    int numberToInsert = int.Parse(splittedInput[1]);
                    int indexToInsert = int.Parse(splittedInput[2]);
                    numbers.Insert(indexToInsert, numberToInsert);
                }

                if (command == "Add" || command == "Remove" || command == "RemoveAt" || command == "Insert")
                {
                    count++;
                }

                if (command == "Contains")
                {
                    int numberToContain = int.Parse(splittedInput[1]);
                    if (numbers.Contains(numberToContain))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command == "PrintEven")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            evens.Add(numbers[i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", evens));
                }
                else if (command == "PrintOdd")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 1)
                        {
                            odds.Add(numbers[i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ",odds));
                }
                else if (command == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (command == "Filter")
                {
                    string condition = splittedInput[1];
                    int numbertoFilter = int.Parse(splittedInput[2]);

                    if (condition == "<")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < numbertoFilter)
                            {
                                filterSmaller.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", filterSmaller));
                    }
                    else if (condition == ">")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] > numbertoFilter)
                            {
                                filterBigger.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", filterBigger));
                    }
                    else if (condition == ">=")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] >= numbertoFilter)
                            {
                                filterBiggerOrEqual.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", filterBiggerOrEqual));
                    }
                    else if (condition == "<=")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= numbertoFilter)
                            {
                                filterSmallerOrEqual.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", filterSmallerOrEqual));
                    }
                }
            }

            if (count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
