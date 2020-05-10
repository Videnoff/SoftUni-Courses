using System;
using _03.Telephony.Contracts;
using _03.Telephony.Core;
using _03.Telephony.IO;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
