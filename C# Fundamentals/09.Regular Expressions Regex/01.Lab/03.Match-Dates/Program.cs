using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace MatchDates
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var regex = @"\b(?<day>\d{2})(\.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            var datesStrings = Console.ReadLine();
            var dates = Regex.Matches(datesStrings,regex);

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
