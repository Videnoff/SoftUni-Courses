using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace NetherRealms
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string healthPattern = @"[^0-9+\-*\/.]";
            Regex healthRegex = new Regex(healthPattern);

            string digitPattern = @"-?\d+\.?\d*";
            Regex digitRegex = new Regex(digitPattern);

            string operatorPattern = @"[*\/]";
            Regex operatorRegex = new Regex(operatorPattern);


            string[] demonNames = Regex.Split(Console.ReadLine(), @"\s*,\s*").OrderBy(x => x).ToArray();

            for (int i = 0; i < demonNames.Length; i++)
            {
                string currentDemon = demonNames[i];
                int currentHealth = 0;

                MatchCollection healthSymbols = healthRegex.Matches(currentDemon);

                foreach (Match symbol in healthSymbols)
                {
                    currentHealth += char.Parse(symbol.Value);
                }

                MatchCollection digitMatch = digitRegex.Matches(currentDemon);

                double baseDamage = 0;

                foreach (Match number in digitMatch)
                {
                    baseDamage += double.Parse(number.Value);
                }

                MatchCollection operatorMatch = operatorRegex.Matches(currentDemon);


                foreach (Match operatorr in operatorMatch)
                {
                    string @operator = operatorr.Value;

                    if (@operator == "*")
                    {
                        baseDamage *= 2;
                    }
                    else
                    {
                        baseDamage /= 2;
                    }
                }

                Console.WriteLine($"{currentDemon} - {currentHealth} health, {baseDamage:F2} damage");
            }
        }
    }
}
