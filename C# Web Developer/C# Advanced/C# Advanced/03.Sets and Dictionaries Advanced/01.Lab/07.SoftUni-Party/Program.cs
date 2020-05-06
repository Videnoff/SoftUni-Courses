using System;
using System.Collections.Generic;

namespace _07.SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            var vip = new HashSet<string>();
            var regular = new HashSet<string>();
            var guestsCame = new HashSet<string>();
            var guestsDidntCame = new HashSet<string>();

            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (command[0] >= '0' && command[0] <= '9')
                {
                    vip.Add(command);
                }
                else
                {
                    regular.Add(command);
                }
            }

            while ((command = Console.ReadLine()) != "END")
            {
                if (vip.Contains(command))
                {
                    vip.Remove(command);
                }
                else if (regular.Contains(command))
                {
                    regular.Remove(command);
                }
                else
                {
                    guestsDidntCame.Add(command);
                }
            }


            Console.WriteLine(vip.Count + regular.Count);

            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }

        }
    }
}
