using System;

namespace TemplatePattern
{
    public class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for 12-grain bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-grain bread! (25 minutes)");
        }
    }
}