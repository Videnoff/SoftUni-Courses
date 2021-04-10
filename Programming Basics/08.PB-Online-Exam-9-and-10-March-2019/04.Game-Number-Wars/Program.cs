using System;

namespace GameNumberWars
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine();

            int points1 = 0;
            int points2 = 0;
            int card1 = 0;
            int card2 = 0;
            bool isNumberWarsWinner1 = false;
            bool isNumberWarsWinner2 = false;
            bool isEndOfGame = false;

            while (true)
            {
                string input1 = Console.ReadLine();

                if (input1 == "End of game")
                {
                    isEndOfGame = true;
                    break;
                }

                string input2 = Console.ReadLine();

                card1 = int.Parse(input1);
                card2 = int.Parse(input2);
                int diff = Math.Abs(card1 - card2);

                if (card1 > card2)
                {
                    points1 += diff;
                }
                else if (card1 < card2)
                {
                    points2 += diff;
                }
                else
                {
                    card1 = int.Parse(Console.ReadLine());
                    card2 = int.Parse(Console.ReadLine());

                    if (card1 > card2)
                    {
                        isNumberWarsWinner1 = true;
                        break;
                    }
                    else if (card1 < card2)
                    {
                        isNumberWarsWinner2 = true;
                        break;
                    }
                }
            }
            if (isNumberWarsWinner1)
            {
                Console.WriteLine("Number wars!");
                Console.WriteLine($"{player1} is winner with {points1} points");
            }
            else if (isNumberWarsWinner2)
            {
                Console.WriteLine("Number wars!");
                Console.WriteLine($"{player2} is winner with {points2} points");
            }
            else if (isEndOfGame == true)
            {
                Console.WriteLine($"{player1} has {points1} points");
                Console.WriteLine($"{player2} has {points2} points");
            }
        }
    }
}
