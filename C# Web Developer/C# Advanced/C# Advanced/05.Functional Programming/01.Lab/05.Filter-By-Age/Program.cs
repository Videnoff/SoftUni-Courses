using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalCats = int.Parse(Console.ReadLine());

            var cats = new List<Cat>();

            for (int i = 0; i < totalCats; i++)
            {
                var currentCatData = Console.ReadLine().Split(", ");

                var cat = new Cat
                {
                    Name = currentCatData[0],
                    Age = int.Parse(currentCatData[1])
                };

                cats.Add(cat);
            }

            var filterText = Console.ReadLine();
            var ageFilter = int.Parse(Console.ReadLine());

            Func<Cat, bool> filterFunc = filterText switch
            {
                "older" => c => c.Age >= ageFilter,
                "younger" => c => c.Age <= ageFilter,
                _ => c => true
            };

            var outputFormat = Console.ReadLine();

            Func<Cat, string> outputFunc = outputFormat switch
            {
                "name age" => c => $"{c.Name} - {c.Age}",
                "name" => c => c.Name,
                _ => c => null
            };

            cats
                .Where(filterFunc)
                .Select(outputFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
