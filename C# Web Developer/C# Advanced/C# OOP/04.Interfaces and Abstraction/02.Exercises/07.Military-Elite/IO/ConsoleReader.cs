using System;
using _07.Military_Elite.IO.Contracts;

namespace _07.Military_Elite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}