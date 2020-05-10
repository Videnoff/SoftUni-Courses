using System;
using _01.Vehicles.Core;
using _01.Vehicles.Core.Contracts;

namespace _01.Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
