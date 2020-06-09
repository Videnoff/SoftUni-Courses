using System;
using System.Linq;

namespace ReverseArrayofStrings
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] texts = Console.ReadLine().Split();
            for (int i = 0; i < texts.Length / 2; i++)
            {
                string first = texts[i];
                string last = texts[texts.Length - i - 1];

                texts[i] = last;
                texts[texts.Length - i - 1] = first;
            }
            for (int i = 0; i < texts.Length; i++)
            {
                Console.Write(texts[i] + " ");
            }
        }
    }
}
