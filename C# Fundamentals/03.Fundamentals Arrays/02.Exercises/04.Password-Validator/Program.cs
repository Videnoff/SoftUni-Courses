using System;

namespace PasswordValidator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isLengthValid = IsLengthValid(password);
            bool areSymbolsValid = AreSymbolsValid(password);
            bool containsAtLeastTwoDigits = ContainsAtLeastTwoDigits(password);

            PrintResult(isLengthValid, areSymbolsValid, containsAtLeastTwoDigits);
        }

        private static void PrintResult(bool isLengthValid, bool areSymbolsValid, bool containsAtLeastTwoDigits)
        {
            if (!isLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!areSymbolsValid)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!containsAtLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isLengthValid && areSymbolsValid && containsAtLeastTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool ContainsAtLeastTwoDigits(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                    if (counter == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool AreSymbolsValid(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsLengthValid(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            return false;
        }
    }
}
