using System;

namespace ReverseStrings
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string words;


            while ((words = Console.ReadLine()) != "end")
            {
                string reversed = "";

                for (int i = words.Length - 1; i >= 0; i--)
                {
                    reversed += words[i];
                }

                Console.WriteLine($"{words} = {reversed}");
            }


        }
    }
}
