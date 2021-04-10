using System;

namespace FootballResults
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string firstMatch = Console.ReadLine();
            string secondMatch = Console.ReadLine();
            string thirdMatch = Console.ReadLine();

            int first = firstMatch.Length;
            int second = secondMatch.Length;
            int third = thirdMatch.Length;

            int wins = 0;
            int loses = 0;
            int draws = 0;


            if (firstMatch[0] > firstMatch[2])
            {
                wins++;
            }
            else if (firstMatch[0] < firstMatch[2])
            {
                loses++;
            }
            else if (firstMatch[0] == firstMatch[2])
            {
                draws++;
            }

            if (secondMatch[0] > secondMatch[2])
            {
                wins++;
            }
            else if (secondMatch[0] < secondMatch[2])
            {
                loses++;
            }
            else if (secondMatch[0] == secondMatch[2])
            {
                draws++;
            }

            if (thirdMatch[0] > thirdMatch[2])
            {
                wins++;
            }
            else if (thirdMatch[0] < thirdMatch[2])
            {
                loses++;
            }
            else if (thirdMatch[0] == thirdMatch[2])
            {
                draws++;
            }

            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {draws}");
        }
    }
}
