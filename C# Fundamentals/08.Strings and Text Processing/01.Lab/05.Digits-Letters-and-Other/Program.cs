using System;

namespace DigitsLettersandOther
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string digits = "";
            string letters = "";
            string others = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    digits += input[i];
                }
                else if (char.IsLetter(input[i]))
                {
                    letters += input[i];
                }
                else
                {
                    others += input[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
