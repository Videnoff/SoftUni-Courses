using System;
using System.Collections.Generic;
using System.Text;
using _03.Telephony.Contracts;

namespace _03.Telephony.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
