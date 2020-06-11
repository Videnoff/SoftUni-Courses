using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ////string regex = @"(^|\s)[+][3][5][9]([\s|-])[2]\2[\d]{3}\2[\d]{4}\b";
            //var regex = new Regex(@"(^|\s)[+][3][5][9]([\s|-])[2]\2[\d]{3}\2[\d]{4}\b"); 

            //var phones = Console.ReadLine();

            ////var phoneMatches = regex.Matches(phones, regex);
            //var phoneMatches = regex.Matches(phones);

            ////foreach (Match match in phoneMatches)
            ////{
            ////    Console.Write($"{match.Value} ");
            ////}
            //var matchedPhones = phoneMatches.Cast<Match>()
            //                                .Select(a => a.Value.Trim()).ToArray();


            ////Console.WriteLine();
            //Console.WriteLine(string.Join(", ", matchedPhones));

            string regex = @"[+][3][5][9]([-|' '])[2]\1[\d]{3}\1[\d]{4}\b";
            string phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones, regex);

            var matxhedPhone = phoneMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", matxhedPhone));
        }
    }
}
