using System;

namespace GreaterofTwoValues
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int result = GetMax(first, second);
                Console.WriteLine(result);
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                char result = GetMax(first, second);
                Console.WriteLine(result);
            }
            else if (type == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                string result = GetMax(first, second);
                Console.WriteLine(result);
            }
        }
        static int GetMax(int first, int second)
        {
            return Math.Max(first, second);
        }
        static char GetMax(char first, char second)
        {
            return (char)Math.Max(first, second);
        }
        static string GetMax(string first, string second)
        {
            int comparison = first.CompareTo(second);
            if (comparison > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
