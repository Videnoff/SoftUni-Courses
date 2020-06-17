using System;
using System.Collections.Generic;
using System.Linq;

namespace NascarQualifications
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> racers = Console.ReadLine().Split().ToList();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splittedInput = input.Split();

                string command = splittedInput[0];
                string racer = splittedInput[1];

                if (command == "Race")
                {
                    if (!racers.Contains(racer))
                    {
                        racers.Add(racer);
                    }
                }
                else if (command == "Accident")
                {
                    racers.Remove(racer);
                }
                else if (command == "Box")
                {
                    if (racers.Contains(racer) && racers.IndexOf(racer) < racers.Count)
                    {
                        int index = racers.IndexOf(racer);
                        racers.RemoveAt(index);
                        racers.Insert(index + 1, racer);
                    }
                }
                else if (command == "Overtake")
                {
                    int positions = int.Parse(splittedInput[2]);
                    int index = racers.IndexOf(racer) - positions;

                    if (racers.Contains(racer))
                    {
                        if ((index >= 0) && positions <= racers.Count)
                        {
                            racers.Remove(racer);
                            racers.Insert(index, racer);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ~ ", racers));
        }
    }
}
