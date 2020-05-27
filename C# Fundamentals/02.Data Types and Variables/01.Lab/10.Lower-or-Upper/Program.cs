using System;

namespace LowerorUpper
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            char ch = char.Parse(Console.ReadLine());

            if ((int)ch >= 97 )
            {
                Console.WriteLine("lower-case");
            }
            else
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}
