using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charsToReplace = {'-', ',', '.', '!', '?'};

            StreamReader streamReader = new StreamReader("text.txt");

            int cnt = 0;

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (cnt % 2 == 0)
                {
                    line = ReplaceAll(charsToReplace, '@', line);

                    line = ReverseWordsInText(line);

                    Console.WriteLine(line);
                }

                cnt++;
            }
        }

        static string ReplaceAll(char[] replace, char replacement, string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char currSymbol = str[i];

                if (replace.Contains(currSymbol))
                {
                    sb.Append('@');
                }
                else
                {
                    sb.Append(currSymbol);
                }
            }

            return sb.ToString().TrimEnd();
        }

        static string ReverseWordsInText(string str)
        {
            StringBuilder sb = new StringBuilder();

            string[] words = str.Split().ToArray();

            int wordsLen = words.Length;

            for (int i = 0; i < wordsLen; i++)
            {
                sb.Append(words[wordsLen - i - 1]);
                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
    }
}
