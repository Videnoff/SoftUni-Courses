using System;
using System.Collections.Generic;

namespace _04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var myDict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!myDict.ContainsKey(number))
                {
                    myDict[number] = 0;
                }

                myDict[number]++;
            }

            foreach (var kvp in myDict)
            {
                if (kvp.Value %2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}
