using System;
using System.Linq;
using System.Collections.Generic;


namespace RandomizeWords
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split().ToList();
            Random rnd = new Random();

            for (int i = 0; i < words.Count; i++)
            {
                var randomindex = rnd.Next(0, words.Count);
                var randomEl = words[randomindex];
                var el = words[i];

                words[randomindex] = el;
                words[i] = randomEl;
            }

            words.ForEach(Console.WriteLine);



            //var random = new Random();

            //var list = Console.ReadLine().Split().ToList();

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var randomIndex = random.Next(0, list.Count);
            //    var randomEl = list[randomIndex];
            //    var el = list[i];

            //    list[randomIndex] = el;
            //    list[i] = randomEl;
            //}

            //list.ForEach(Console.WriteLine);
        }
    }
}
