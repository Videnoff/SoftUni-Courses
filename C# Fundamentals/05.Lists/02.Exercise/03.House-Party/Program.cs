using System;
using System.Linq;
using System.Collections.Generic;

namespace HouseParty
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < commands; i++)
            {
                string[] sentence = Console.ReadLine().Split();

                if (sentence.Length == 3)
                {
                    if (guests.Contains(sentence[0]))
                    {
                        Console.WriteLine($"{sentence[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(sentence[0]);
                    }
                }
                else if (sentence.Length == 4)
                {
                    if (guests.Contains(sentence[0]))
                    {
                        guests.Remove(sentence[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{sentence[0]} is not in the list!");
                    }
                }
            }
            //Console.WriteLine(string.Join("\n", guests));
            guests.ForEach(Console.WriteLine);
        }
    }
}
