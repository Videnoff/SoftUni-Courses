using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Furniture
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string pattern = @"^>>(?<name>.+)<<(?<price>[\d]+\.?[\d]*)!(?<quantity>[\d]+)";
            List<string> furnitures = new List<string>();

            decimal totalSpentMoney = 0;

            string input;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furnitures.Add(name);
                    totalSpentMoney += price * quantity;
                }
            }

            Console.WriteLine($"Bought furniture:");

            foreach (var furniture in furnitures)
            {
                Console.WriteLine($"{furniture}");
            }

            Console.WriteLine($"Total money spend: {totalSpentMoney:F2}");
        }
    }
}
