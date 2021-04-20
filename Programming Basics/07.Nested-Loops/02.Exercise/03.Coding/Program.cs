using System;

namespace Coding
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char currentDig = input[i];
                int currentDigitToNum = int.Parse(currentDig.ToString());
                //Console.WriteLine(currentDigitToNum);

                if (currentDigitToNum == 0)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }
                for (int j = 1; j <= currentDigitToNum; j++)
                {
                    Console.Write((char)(currentDigitToNum + 33));
                }
                Console.WriteLine();
            }
        }
    }
}
