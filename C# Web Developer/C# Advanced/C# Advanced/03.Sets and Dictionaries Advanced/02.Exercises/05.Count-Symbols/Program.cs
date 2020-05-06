using System;
using System.Collections.Generic;

namespace _05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var myDic = new SortedDictionary<char, int>();

            foreach (var element in text)
            {
                if (!myDic.ContainsKey(element))
                {
                    myDic[element] = 0;
                }

                myDic[element]++;
            }

            foreach (var element in myDic)
            {
                Console.WriteLine($"{element.Key}: {element.Value} time/s");
            }

            ;
        }
    }
}
