using System;

namespace DanceHall
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double hallLength = double.Parse(Console.ReadLine());
            double hallWidth = double.Parse(Console.ReadLine());
            double wardrobeSide = double.Parse(Console.ReadLine());

            double hallSize = (hallLength * 100) * (hallWidth * 100);
            double benchSize = hallSize / 10;
            double wardrobeSize = (wardrobeSide * 100) * (wardrobeSide * 100);
            double clearArea = hallSize - benchSize - wardrobeSize;
            double dancerPlace = clearArea / 7040;

            Console.WriteLine(Math.Floor(dancerPlace));
        }
    }
}
