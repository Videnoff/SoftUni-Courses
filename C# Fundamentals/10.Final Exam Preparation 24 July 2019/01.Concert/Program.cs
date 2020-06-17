using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();
            Dictionary<string, int> playTime = new Dictionary<string, int>();

            int totalTime = 0;

            while (input != "start of concert")
            {
                string[] splittedInput = input.Split(new[] { "; " }, StringSplitOptions.None);
                string command = splittedInput[0];
                string name = splittedInput[1];



                if (command == "Add")
                {
                    List<string> members = splittedInput[2].Split(new[] { ", " }, StringSplitOptions.None).ToList();

                    if (!bands.ContainsKey(name))
                    {
                        bands.Add(name, members);
                    }
                    else
                    {
                        foreach (var member in members)
                        {
                            if (!bands[name].Contains(member))
                            {
                                bands[name].Add(member);
                            }
                        }
                    }
                }
                else
                {
                    int time = int.Parse(splittedInput[2]);
                    totalTime += time;

                    if (!playTime.ContainsKey(name))
                    {
                        playTime.Add(name, time);
                    }
                    else
                    {
                        playTime[name] += time;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var band in playTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            string bandToLookFor = Console.ReadLine();

            Console.WriteLine(bandToLookFor);

            foreach (var member in bands[bandToLookFor])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
