using System;
using System.Linq;
using System.Collections.Generic;

namespace WordSynonyms
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //var total = int.Parse(Console.ReadLine());
            //var words = new Dictionary<string, List<string>>();

            //for (int i = 0; i < total; i++)
            //{
            //    var word = Console.ReadLine();
            //    var synonym = Console.ReadLine();

            //    if (!words.ContainsKey(word))
            //    {
            //        words[word] = new List<string>();
            //    }

            //    words[word].Add(synonym);
            //}

            //foreach (var item in words)
            //{
            //    var word = item.Key;
            //    var synonyms = item.Value;

            //    Console.WriteLine($"{word} - {string.Join(", ", synonyms)}");
            //}






            var words = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                var synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                }

                words[word].Add(synonym);
            }

            foreach (var item in words)
            {
                var word = item.Key;
                var synonyms = item.Value;

                Console.WriteLine($"{word} - {string.Join(", ", synonyms)}");
            }
        }
    }
}
