using System;
using System.Linq;
using System.Collections.Generic;

namespace ChangeList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List <int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splittedInput = input.Split();

                if (splittedInput[0] == "Delete")
                {
                    int numberToDelete = int.Parse(splittedInput[1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numberToDelete == numbers[i])
                        {
                            numbers.Remove(numberToDelete);
                        }
                    }
                }
                else if (splittedInput[0] == "Insert")
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
