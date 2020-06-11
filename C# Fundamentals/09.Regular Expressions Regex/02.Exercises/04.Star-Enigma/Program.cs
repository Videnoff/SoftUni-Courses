using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace StarEnigma
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int countMessages = int.Parse(Console.ReadLine());

            string firstPattern = @"[starSTAR]";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < countMessages; i++)
            {
                string message = Console.ReadLine();

                MatchCollection lettersMatched = Regex.Matches(message, firstPattern);

                int countOfLetters = lettersMatched.Count;
                string newMessage = string.Empty;

                foreach (var letter in message)
                {
                    newMessage += (char)(letter - countOfLetters);
                }

                string planetPattern = @"@(?<planetName>[A-Za-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<attackType>A|D)![^@\-!:>]*->(?<soldierCount>[\d]+)";

                Match planetArgs = Regex.Match(newMessage, planetPattern);

                if (planetArgs.Success)
                {
                    string planetName = planetArgs.Groups["planetName"].Value;
                    string type = planetArgs.Groups["attackType"].Value;

                    if (type == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (type == "D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var attackedPlanet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {attackedPlanet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var destroyedPlanet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {destroyedPlanet}");
            }
        }
    }
}
