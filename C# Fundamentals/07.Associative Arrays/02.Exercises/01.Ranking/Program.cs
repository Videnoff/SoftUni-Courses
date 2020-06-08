using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input;
            Dictionary<string, string> contestPass = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> verificator = new SortedDictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] splittedInput = input.Split(new[] { ":" }, StringSplitOptions.None);
                string contest = splittedInput[0];
                string password = splittedInput[1];

                if (!contestPass.ContainsKey(contest))
                {
                    contestPass.Add(contest, password);
                }

            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] splittedInput = input.Split(new[] { "=>" }, StringSplitOptions.None);
                string contest = splittedInput[0];
                string password = splittedInput[1];
                string username = splittedInput[2];
                int points = int.Parse(splittedInput[3]);

                if (contestPass.ContainsKey(contest) && contestPass.ContainsValue(password))
                {
                    if (!verificator.ContainsKey(username))
                    {
                        verificator.Add(username, new Dictionary<string, int>());
                        verificator[username].Add(contest, points);
                    }

                    if (verificator[username].ContainsKey(contest))
                    {
                        if (verificator[username][contest] < points)
                        {
                            verificator[username][contest] = points;
                        }
                    }
                    else
                    {
                        verificator[username].Add(contest, points);
                    }
                }
            }

            Dictionary<string, int> userNameTotalPoints = new Dictionary<string, int>();

            foreach (var kvp in verificator)
            {
                userNameTotalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            string bestName = userNameTotalPoints.Keys.Max();
            int bestPoints = userNameTotalPoints.Values.Max();

            foreach (var kvp in userNameTotalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");
                }
            }

            Console.WriteLine("Ranking: ");

            foreach (var name in verificator)
            {
                Dictionary<string, int> dict = name.Value;
                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine($"{name.Key}");

                foreach (var kvp in dict)
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
