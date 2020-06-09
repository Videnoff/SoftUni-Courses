using System;

namespace CharacterMultiplier
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();

            string firstString = strings[0];
            string secondString = strings[1];

            string minStr = string.Empty;
            string maxStr = string.Empty;

            if (firstString.Length > secondString.Length)
            {
                minStr = secondString;
                maxStr = firstString;
            }
            else
            {
                minStr = firstString;
                maxStr = secondString;
            }

            int totalSum = 0;

            for (int i = 0; i < minStr.Length; i++)
            {
                totalSum += minStr[i] * maxStr[i];
            }

            for (int i = minStr.Length; i < maxStr.Length; i++)
            {
                totalSum += maxStr[i];
            }

            Console.WriteLine(totalSum);
        }
    }
}
