using System;
using _03.Shopping_Spree.Core;

namespace _03.Shopping_Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine();

                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
