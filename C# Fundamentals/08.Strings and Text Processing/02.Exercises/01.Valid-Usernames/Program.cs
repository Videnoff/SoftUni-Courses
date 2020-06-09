using System;

namespace ValidUsernames
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                                        .Split(new string[] { ", " }
                                               , StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < usernames.Length; i++)
            {
                string currentUsername = usernames[i];

                bool isLengthValid = true;
                bool isContelntValid = true;

                if (currentUsername.Length < 3 || currentUsername.Length > 16)
                {
                    isLengthValid = false;
                }

                for (int j = 0; j < currentUsername.Length; j++)
                {
                    char currentSymbol = currentUsername[j];

                    if (!char.IsLetterOrDigit(currentSymbol) && currentSymbol != '-' && currentSymbol != '_')
                    {
                        isContelntValid = false;
                        break;
                    }
                }

                if (isLengthValid && isContelntValid)
                {
                    Console.WriteLine(currentUsername);
                }
            }
        }
    }
}
