using System;

namespace Choreography
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double steps = double.Parse(Console.ReadLine());
            double dancers = double.Parse(Console.ReadLine());
            double learnDays = double.Parse(Console.ReadLine());

            double stepsPercentPerDay = Math.Ceiling(((steps / learnDays) / steps) * 100);
            double stepsPercentPerDancer = (stepsPercentPerDay / dancers);


            if (stepsPercentPerDay <= 13)
            {
                Console.WriteLine("Yes, they will succeed in that goal! {0:F2}%.", stepsPercentPerDancer);
            }
            else
            {
                Console.WriteLine("No, they will not succeed in that goal! Required {0:F2}% steps to be learned per day.", stepsPercentPerDancer);
            }
        }
    }
}
