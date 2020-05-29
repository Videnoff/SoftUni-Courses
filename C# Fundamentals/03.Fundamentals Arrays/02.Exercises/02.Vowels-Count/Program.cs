using System;
using System.Linq;

namespace VowelsCount
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            int counter = 0;
            counter = GetVoewls(word, counter);
            Console.WriteLine(counter);
        }

        private static int GetVoewls(string word, int counter)
        {
            string vowels = "aouei";
            //char[] vowels = { 'a', 'o', 'u', 'e', 'i'};
            for (int i = 0; i < word.Length; i++)
            {
                char currentSymbol = word[i];
                if (vowels.Contains(currentSymbol))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
