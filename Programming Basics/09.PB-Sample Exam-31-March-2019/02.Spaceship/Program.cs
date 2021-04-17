using System;

namespace Spaceship
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double shipWidth = double.Parse(Console.ReadLine());
            double shipLenght = double.Parse(Console.ReadLine());
            double shipHeight = double.Parse(Console.ReadLine());
            double averageHeight = double.Parse(Console.ReadLine());

            double shipVolume = shipWidth * shipLenght * shipHeight;
            double cosmRoom = 2.0 * 2.0 * (averageHeight + 0.40);
            double space = shipVolume / cosmRoom;

            if (space >= 3 && space <= 10)
            {
                Console.WriteLine($"The spacecraft holds {Math.Floor(space)} astronauts.");
            }
            else if (space < 3)
            {
                Console.WriteLine($"The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine($"The spacecraft is too big.");
            }
        }
    }
}
