using System;
using System.IO;
using System.Linq;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("./text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string currLine = lines[i];

                int lettersCount = CountOfLetters(currLine);
                int marksCount = CountOfPunctuationalMarks(currLine);

                lines[i] = $"Line {i + 1}: {currLine} ({lettersCount})";
            }

            File.WriteAllLines("../../../output.txt", lines);
        }

        static int CountOfLetters(string line)
        {
            int cnt = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];

                if (char.IsLetter(currSymbol))
                {
                    cnt++;
                }
            }

            return cnt;
        }

        static int CountOfPunctuationalMarks(string line)
        {
            char[] marks = { '-', ',', '.', '!', '?', };

            int cnt = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];

                if (marks.Contains(currSymbol))
                {
                    cnt++;
                }
            }

            return cnt;
        }
    }
}
