using System;
using System.Linq;

namespace EncryptSortandPrintArray
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            string vowels = "aAeEiIoOuU";
            char[] vowelsArr = vowels.ToCharArray();
            string consonants = "bBcCdDfFgGhHjJkKlLmMnNpPqQrRsStTvVwWxXzZyY";
            char[] consonantsArr = consonants.ToCharArray();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                char[] letters = name.ToCharArray();

                int sum = 0;

                for (int j = 0; j < letters.Length; j++)
                {
                    char currentChar = letters[j];
                    if (vowelsArr.Contains(currentChar))
                    {
                        sum += letters[j] * letters.Length;
                    }
                    else
                    {
                        sum += letters[j] / letters.Length;
                    }
                }
                numbers[i] = sum;
            }
            Array.Sort(numbers);
            foreach (var number in numbers)
            {
                Console.WriteLine($"{number}");
            }
        }
    }
}
