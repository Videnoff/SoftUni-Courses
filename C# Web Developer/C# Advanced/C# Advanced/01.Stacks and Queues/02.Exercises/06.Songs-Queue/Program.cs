using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");

            var queue = new Queue<string>(input);

            while (queue.Any())
            {
                var command = Console.ReadLine().Split();
                var secondCommand = string.Empty;


                if (command[0] == "Play")
                {
                    queue.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        secondCommand += string.Join(" ", command[i] + " ");
                    }

                    secondCommand = secondCommand.Trim();

                    if (!queue.Contains(secondCommand))
                    {
                        queue.Enqueue(secondCommand);
                    }
                    else
                    {
                        Console.WriteLine($"{secondCommand} is already contained!");
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }

            Console.WriteLine($"No more songs!");
        }
    }
}
