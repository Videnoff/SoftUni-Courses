using System;
using _07.Military_Elite.Contracts;
using _07.Military_Elite.Core;
using _07.Military_Elite.Core.Contracts;
using _07.Military_Elite.IO;
using _07.Military_Elite.IO.Contracts;

namespace _07.Military_Elite
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
