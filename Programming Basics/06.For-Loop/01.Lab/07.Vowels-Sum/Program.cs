using System;

namespace VowelsSum
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char letter = s[i];
                if (letter == 'a')
                {
                    sum += 1;
                }
                else if (letter == 'e')
                {
                    sum += 2;
                }
                else if (letter == 'i')
                {
                    sum += 3;
                }
                else if (letter == 'o')
                {
                    sum += 4;
                }
                else if (letter == 'u')
                {
                    sum += 5;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
