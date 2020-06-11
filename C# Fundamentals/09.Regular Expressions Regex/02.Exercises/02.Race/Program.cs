using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Race
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(new [] { ", " }, StringSplitOptions.None).ToList();
            string input;
            string pattern = @"(?<name>[A-Za-z]*)(?<distance>[\d]*)";

            while ((input = Console.ReadLine()) != "end of race")
            {
                Match patternArgs = Regex.Match(input, pattern);
                if (patternArgs.Success)
                {
                    string participantName = patternArgs.Groups["name"].Value;
                    string participantDistance = patternArgs.Groups["distance"].Value;
                }

            }
        }
    }
}