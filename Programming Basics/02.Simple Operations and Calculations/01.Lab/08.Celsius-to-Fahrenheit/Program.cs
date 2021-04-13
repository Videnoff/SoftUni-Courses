using System;

namespace CelsiustoFahrenheit
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double celcius = double.Parse(Console.ReadLine());
            double fahrenheit = (celcius * 9) / 5 + 32;
            Console.WriteLine("{0:F2}", fahrenheit);
        }
    }
}
