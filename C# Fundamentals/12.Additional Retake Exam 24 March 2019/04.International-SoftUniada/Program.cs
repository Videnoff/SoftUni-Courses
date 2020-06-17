using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace InternationalSoftUniada
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input;
            Dictionary<string, Dictionary<string, int>> contestants = new Dictionary<string, Dictionary<string, int>>();


            while ((input = Console.ReadLine()) != "END")
            {
                string[] splittedinput = input.Split(new[] { " -> " }, StringSplitOptions.None);

                string countryName = splittedinput[0];
                string contestantName = splittedinput[1];
                int contestantPoints = int.Parse(splittedinput[2]);


                if (!contestants.ContainsKey(countryName))
                {
                    contestants.Add(countryName, new Dictionary<string, int>());
                    contestants[countryName].Add(contestantName, contestantPoints);
                }
                else if (contestants.ContainsKey(countryName))
                {
                    if (!contestants[countryName].ContainsKey(contestantName))
                    {
                        contestants[countryName].Add(contestantName, contestantPoints);
                    }
                    else if (contestants[countryName].ContainsKey(contestantName))
                    {
                        contestants[countryName][contestantName] += contestantPoints;
                    }
                }
            }

            foreach (var item in contestants.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()}");

                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($" -- {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
