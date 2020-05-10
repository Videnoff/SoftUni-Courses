using System;
using _03.Telephony.Contracts;

namespace _03.Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}