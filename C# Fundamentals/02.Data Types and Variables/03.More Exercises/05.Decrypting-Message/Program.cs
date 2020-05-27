using System;

namespace DecryptingMessage
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            int counter = lines;
            string word = "";
            while (counter > 0)
            {
                char letters = char.Parse(Console.ReadLine());
                word += (char)(letters + key);
                counter--;
            }
            Console.WriteLine(word);
        }
    }
}
