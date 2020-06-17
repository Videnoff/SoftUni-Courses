using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace StringManipulator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string result = string.Empty;
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splittedInput = input.Split();
                string command = splittedInput[0];

                if (command == "Add")
                {
                    string newStringToAdd = splittedInput[1];
                    result += newStringToAdd;
                }
                else if (command == "Upgrade")
                {
                    char oldChar = char.Parse(splittedInput[1]);
                    result = result.Replace(oldChar, (char)(oldChar + 1));
                }
                else if (command == "Print")
                {
                    Console.WriteLine(result);
                }
                else if (command == "Index")
                {
                    char symbol = char.Parse(splittedInput[1]);
                    List<int> indexes = new List<int>();
                    int startIndex = 0;

                    while (result.IndexOf(symbol, startIndex) != -1)
                    {
                        int index = result.IndexOf(symbol, startIndex);

                        indexes.Add(index);
                        startIndex = index + 1;
                    }

                    //for (int i = 0; i < result.Length; i++)
                    //{
                    //    char currentSymbol = result[i];

                    //    if (currentSymbol == symbol)
                    //    {
                    //        indexes.Add(i);
                    //    }
                    //}

                    if (!indexes.Any())
                    {
                        Console.WriteLine("None");
                    }
                    else
                    {
                        Console.WriteLine(string.Join(" ", indexes));
                    }
                }
                else if (command == "Remove")
                {
                    string searchedStr = splittedInput[1];
                    result = result.Replace(searchedStr, "");

                    //while (result.Contains(searchedStr))
                    //{
                    //    int index = result.IndexOf(searchedStr);

                    //    result = result.Remove(index, searchedStr.Length);
                    //}
                }


                input = Console.ReadLine();
            }
        }
    }
}
