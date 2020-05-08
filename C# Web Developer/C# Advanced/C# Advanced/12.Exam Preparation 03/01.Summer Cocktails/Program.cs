using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Mimosa = 150;
            const int Daiquiri = 250;
            const int Sunshine = 300;
            const int Mojito = 400;


            var inputIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputFreshnessLevel = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var ingredients = new Queue<int>(inputIngredients);
            var freshnessLevel = new Stack<int>(inputFreshnessLevel);

            var cocktails = new Dictionary<string, int>
            {
                {"Mimosa", 0},
                {"Daiquiri", 0},
                {"Sunshine", 0},
                {"Mojito", 0}
            };



            while (ingredients.Count > 0 && freshnessLevel.Count > 0)
            {
                var currentIngredient = ingredients.Dequeue();

                if (currentIngredient != 0)
                {
                    var currentFreshness = freshnessLevel.Pop();

                    var mix = currentIngredient * currentFreshness;

                    if (mix == 150)
                    {
                        cocktails["Mimosa"]++;
                    }
                    else if (mix == 250)
                    {
                        cocktails["Daiquiri"]++;
                    }
                    else if (mix == 300)
                    {
                        cocktails["Sunshine"]++;
                    }
                    else if (mix == 400)
                    {
                        cocktails["Mojito"]++;
                    }
                    else
                    {
                        ingredients.Enqueue(currentIngredient + 5);
                    }
                }
            }

            if (!cocktails.ContainsValue(0))
            {
                Console.WriteLine($"It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine($"What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var cocktail in cocktails.OrderBy(x => x.Key))
            {
                if (cocktail.Value > 0)
                {
                    Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
                }
            }
        }
    }
}
