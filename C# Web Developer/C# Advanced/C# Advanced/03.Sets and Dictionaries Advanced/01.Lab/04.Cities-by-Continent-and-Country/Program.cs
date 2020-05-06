using System;
using System.Collections.Generic;

namespace _04.Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            /*
             * Input:
               8
               Africa Somalia Mogadishu
               Asia India Mumbai
               
             */

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var splittedInput = input.Split();
                var continentName = splittedInput[0];
                var countryName = splittedInput[1];
                var cityName = splittedInput[2];

                if (!continents.ContainsKey(continentName))
                {
                    continents.Add(continentName, new Dictionary<string, HashSet<string>>());
                }

                var continent = continents[continentName];

                if (!continent.ContainsKey(countryName))
                {
                    continent.Add(countryName, new HashSet<string>());
                }

                var country = continent[countryName];

                if (!country.Contains(cityName))
                {
                    country.Add(cityName);
                }
            }

            ;
            /*
             * Output:
               Africa:
               Somalia -> Mogadishu
               Asia:
               India -> Mumbai, Delhi, Nagpur
               
             */

            foreach (var continent in continents)
            {
                Console.WriteLine(continent.Key + ":");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }

        }
    }
}
