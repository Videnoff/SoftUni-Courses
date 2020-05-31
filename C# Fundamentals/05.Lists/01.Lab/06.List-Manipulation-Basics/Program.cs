using System;
using System.Linq;
using System.Collections.Generic;

namespace ListManipulationBasics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] splittedInput = command.Split();
                string input = splittedInput[0];
                string secInput = splittedInput[1];

                if (input == "Add")
                {
                    int numberToAdd = int.Parse(splittedInput[1]);
                    numbers.Add(numberToAdd);
                    
                }
                else if (input == "Remove")
                {
                    int numberToRemove = int.Parse(splittedInput[1]);
                    numbers.Remove(numberToRemove);
                    
                }
                else if (input == "RemoveAt")
                {
                    int indexToRemove = int.Parse(splittedInput[1]);
                    numbers.RemoveAt(indexToRemove);
                    
                }
                else if (input == "Insert")
                {
                    int numberToInsert = int.Parse(splittedInput[1]);
                    int indexToInsert = int.Parse(splittedInput[2]);
                    numbers.Insert(indexToInsert, numberToInsert);
                    
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
