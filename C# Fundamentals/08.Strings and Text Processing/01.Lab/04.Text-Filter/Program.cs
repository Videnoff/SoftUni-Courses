using System;

namespace TextFilter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new string[]{ ", " }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();

            foreach (var word in words)
            {
                if (text.Contains(word))
                {
                    text = text.Replace(word, new string('*', word.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
