using System;

namespace RepeatStrings
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            string result = "";

            foreach (var word in words)
            {
                int repeatTimes = word.Length;
                for (int i = 0; i < repeatTimes; i++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
