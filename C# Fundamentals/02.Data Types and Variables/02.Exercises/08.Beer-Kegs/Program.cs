using System;

namespace BeerKegs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int kegsCount = int.Parse(Console.ReadLine());
            string model = "";
            double volume = 0.0;

            for (int i = 0; i < kegsCount; i++)
            {
                string currentModel = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currentVolume = Math.PI * Math.Pow(radius, 2) * height;

                if (currentVolume > volume)
                {
                    volume = currentVolume;
                    model = currentModel;
                }
            }
            Console.WriteLine(model);
        }
    }
}
