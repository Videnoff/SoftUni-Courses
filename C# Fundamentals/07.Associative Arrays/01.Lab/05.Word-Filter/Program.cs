using System;
using System.Linq;
using System.Collections.Generic;

namespace WordFilter
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            // First Option:

            //    Console.ReadLine().Split().Where(w => w.Length % 2 == 0).ToList()
            //           .ForEach(x => { Console.WriteLine(x); });
            //

            // Second Option:

            string[] words = Console.ReadLine().Split().Where(w => w.Length % 2 == 0).ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
