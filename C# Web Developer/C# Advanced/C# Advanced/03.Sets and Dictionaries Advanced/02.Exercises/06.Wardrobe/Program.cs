using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                var splittedLine = line.Split(" -> ");
                var color = splittedLine[0];
                var clothes = splittedLine[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    string dress = clothes[j];

                    if (!wardrobe[color].ContainsKey(dress))
                    {
                        wardrobe[color][dress] = 0;
                    }

                    wardrobe[color][dress]++;
                }

            }

            var searchedClothes = Console.ReadLine();
            var splittedSearch = searchedClothes.Split(" ");
            var searchedColor = splittedSearch[0];
            var searchedItem = splittedSearch[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var dress in item.Value)
                {
                    if (item.Key == searchedColor && dress.Key == searchedItem)
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value}");
                    }
                }
            }
        }
    }
}
