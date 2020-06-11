using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"\b[A-Z]{1}[a-z]+[' '][A-Z]{1}[a-z]+\b";

            MatchCollection matchNames = Regex.Matches(text, pattern);

            foreach (Match name in matchNames)
            {
                Console.Write($"{name.Value}" + " ");
            }

            Console.WriteLine();
        }
    }
}
