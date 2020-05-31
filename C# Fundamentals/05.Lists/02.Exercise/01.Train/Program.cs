using System;
using System.Linq;
using System.Collections.Generic;

namespace Train
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splittedInput = input.Split();

                if (splittedInput.Length == 1)
                {
                    int passengers = int.Parse(splittedInput[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= capacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
                else
                {
                    int passengers = int.Parse(splittedInput[1]);
                    wagons.Add(passengers);
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
