using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;

namespace EmojiSumator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emojiCodeAsStr = Console.ReadLine();

            int[] asciiCodes = emojiCodeAsStr.Split(new[] { ":" }, StringSplitOptions.None)
                                             .Select(int.Parse).ToArray();

            string emojiCode = ":";

            for (int i = 0; i < asciiCodes.Length; i++)
            {
                emojiCode += (char)asciiCodes[i];
            }

            emojiCode += ":";

            string pattern = @"(?<emoji>:(?<emojiValue>[a-z]{4,}):)(|,|\.|!|\?)";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> emojis = matches.Cast<Match>().Select(x => x.Groups["emoji"].Value).ToList();

            int emojiPower = 0;

            foreach (var emoji in emojis)
            {
                foreach (var symbol in emoji)
                {
                    if (symbol != ':')
                    {
                        emojiPower += symbol;
                    }
                }
            }

            if (emojis.Contains(emojiCode))
            {
                emojiPower *= 2;
            }

            if (emojis.Any())
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", emojis)}");
            }

            Console.WriteLine($"Total Emoji Power: {emojiPower}");
        }
    }
}
