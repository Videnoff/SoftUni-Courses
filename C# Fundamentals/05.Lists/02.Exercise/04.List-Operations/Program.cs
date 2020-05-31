using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOperations
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedInput = input.Split();
                string command = splittedInput[0];
                switch (command)
                {
                    case "Add":
                        int numberToAdd = int.Parse(splittedInput[1]);
                        numbers.Add(numberToAdd);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(splittedInput[1]);
                        int indexToInsert = int.Parse(splittedInput[2]);
                        bool isIndexValid = IsIndexValid(indexToInsert, 0, numbers.Count);

                        if (isIndexValid)
                        {
                            numbers.Insert(indexToInsert, numberToInsert);
                        }
                        break;
                    case "Remove":
                        int indexToRemove = int.Parse(splittedInput[1]);
                        isIndexValid = IsIndexValid(indexToRemove, 0, numbers.Count);

                        if (isIndexValid)
                        {
                            numbers.RemoveAt(indexToRemove);
                        }
                        break;
                    case "Shift":
                        if (splittedInput[1] == "left")
                        {
                            int count = int.Parse(splittedInput[2]);
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else if (splittedInput[1] == "right")
                        {
                            int count = int.Parse(splittedInput[2]);
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Insert(0, numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static bool IsIndexValid(int index, int minRange, int maxRange)
        {
            if (index < minRange || index >= maxRange)
            {
                Console.WriteLine("Invalid index");
                return false;
            }
            return true;
        }
    }
}
