using System;

namespace NameWars
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int maxSum = int.MinValue;
            string winner = string.Empty;

            while (name != "STOP")
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    char curr = name[i];
                    sum += (int)curr;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    winner = name;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"Winner is {winner} - {maxSum}!");
        }
    }
}
