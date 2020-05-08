using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Dating_App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] malesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] femalesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> males = new Stack<int>(malesInput);
            Queue<int> females = new Queue<int>(femalesInput);

            int matchesCount = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currentMale = males.Peek();
                int currenFemale = females.Peek();

                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }

                if (currenFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (currentMale % 25 == 0)
                {
                    males.Pop();

                    if (males.Count > 0)
                    {
                        males.Pop();
                    }

                    continue;
                }


                if (currenFemale % 25 == 0)
                {
                    females.Dequeue();


                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }

                    continue;
                }

                if (currentMale == currenFemale)
                {
                    matchesCount++;

                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    males.Pop();
                    males.Push(currentMale - 2);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            string maleString = males.Count > 0 ? string.Join(", ", males) : "none";
            Console.WriteLine($"Males left: {maleString}");

            string femalesString = females.Count > 0 ? string.Join(", ", females) : "none";
            Console.WriteLine($"Females left: {femalesString}");
        }
    }
}
