﻿using System;

namespace RepeatString
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatString(text, count));
        }

        private static string RepeatString(string text, int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += text;
            }
            return result;
        }
    }
}
