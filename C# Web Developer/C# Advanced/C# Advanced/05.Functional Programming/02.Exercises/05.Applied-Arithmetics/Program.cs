using System;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = (arr) =>
            {
                Console.WriteLine(string.Join(" ", arr));
            };


            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int[], int[]> processor = GetProcessor(input);

                    numbers = processor(numbers);
                }


            }
        }

        static Func<int[], int[]> GetProcessor(string command)
        {
            Func<int[], int[]> processor = null;

            if (command == "add")
            {
                processor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]++;
                    }

                    return arr;
                });
            }
            else if (command == "multiply")
            {
                processor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i] * 2;
                    }

                    return arr;
                });
            }
            else if (command == "subtract")
            {
                processor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]--;
                    }

                    return arr;
                });
            }

            return processor;
        }
    }
}
