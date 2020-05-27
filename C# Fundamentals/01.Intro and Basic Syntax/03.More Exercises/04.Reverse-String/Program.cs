using System;

namespace ReverseString
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string result = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            Console.WriteLine(result);
        }
    }
}
