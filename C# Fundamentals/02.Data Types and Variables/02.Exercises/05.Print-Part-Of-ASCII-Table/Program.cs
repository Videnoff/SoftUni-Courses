﻿using System;

namespace PrintPartOfASCIITable
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
