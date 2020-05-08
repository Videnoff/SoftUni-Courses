using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            var plates = Console.ReadLine().Split().Select(int.Parse).ToList();

            var warriors = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                var inputWarriors = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (!plates.Any())
                {
                    break;
                }

                foreach (var warrior in inputWarriors)
                {
                    warriors.Push(warrior);
                }

                if (i % 3 == 0)
                {
                    var plateToAdd = int.Parse(Console.ReadLine());
                    plates.Add(plateToAdd);
                }


                while (plates.Any() && warriors.Any())
                {
                    var currentWarrior = warriors.Pop();
                    var currentPlate = plates[0];

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        warriors.Push(currentWarrior);
                        plates.RemoveAt(0);
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        currentPlate -= currentWarrior;
                        plates[0] = currentPlate;
                    }
                    else
                    {
                        plates.RemoveAt(0);
                    }
                }
            }

            if (warriors.Any())
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                Console.Write($"Warriors left: {string.Join(", ", warriors)}");
            }
            else
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.Write($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
