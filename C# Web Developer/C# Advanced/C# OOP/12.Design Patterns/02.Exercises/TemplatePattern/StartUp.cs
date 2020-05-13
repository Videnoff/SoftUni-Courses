using System;

namespace TemplatePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();
            Console.WriteLine();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            Console.WriteLine();

            WhiteWheat whiteWheat = new WhiteWheat();
            whiteWheat.Make();
        }
    }
}
