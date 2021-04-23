using System;

namespace Cake
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int pieces = a * b;
            string command = Console.ReadLine();
            int numberTakenPieces = 0;
            while (command != "STOP" && numberTakenPieces <= pieces)
            {
                int takePieces = int.Parse(command);
                numberTakenPieces += takePieces;
                command = Console.ReadLine();
            }
            int difference = pieces - numberTakenPieces;
            if (command == "STOP" && difference > 0)
            {
                Console.WriteLine($"{difference} pieces are left.");
            }
            else if (difference < 0)
            {
                difference = Math.Abs(difference);
                Console.WriteLine($"No more cake left! You need {difference} pieces more.");
            }
        }
    }
}
