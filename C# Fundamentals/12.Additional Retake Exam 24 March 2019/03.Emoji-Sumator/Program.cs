using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace EmojiSumator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emojiCode = Console.ReadLine();

            int[] asciiCodes = emojiCode.Split(new[] { ":" }, StringSplitOptions.None).Select(int.Parse).ToArray();

            string separator = " :";

            for (int i = 0; i < asciiCodes.Length; i++)
            {
                separator += (char)asciiCodes[i];
            }

            separator += ": ";

            string pattern = @"(?<emoji>\s:[a-z]{4,}:[ |‘|'|`|\.|,|!\|?|.])";

            MatchCollection matches = Regex.Matches(text, pattern);
            List<string> emojis = matches.Cast<Match>().Select(x => x.Groups["emoji"].Value).ToList();

            int emojiPower = 0;

            foreach (var emoji in emojis)
            {
                foreach (var symbol in emoji)
                {
                    if (symbol != ':' && symbol != ' ')
                    {
                        emojiPower += symbol;
                    }
                }
            }

            if (emojis.Contains(separator))
            {
                emojiPower *= 2;
            }

            if (emojis.Any())
            {
                Console.WriteLine($"Emojis found: {string.Join(",", emojis.Where(s => !string.IsNullOrWhiteSpace(s)))}");
            }

            Console.WriteLine($"Total Emoji Power: {emojiPower}");
        }
    }
}
