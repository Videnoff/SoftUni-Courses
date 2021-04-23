using System;

namespace Moving
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string packets = Console.ReadLine();
            int homeVolume = width * lenght * height;
            int totalBoxes = 0;

            while (packets != "Done")
            {
                int boxes = int.Parse(packets);
                totalBoxes += boxes;
                if (totalBoxes >= homeVolume)
                {
                    Console.WriteLine($"No more free space! You need {totalBoxes - homeVolume} Cubic meters more.");
                    break;
                }
                packets = Console.ReadLine();
            }
            if (packets == "Done")
            {
                Console.WriteLine($"{homeVolume - totalBoxes} Cubic meters left.");
            }
        }
    }
}
