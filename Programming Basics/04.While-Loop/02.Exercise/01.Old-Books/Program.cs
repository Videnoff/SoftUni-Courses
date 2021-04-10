using System;

namespace OldBooks
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string favBook = Console.ReadLine();
            int libCapacity = int.Parse(Console.ReadLine());
            int counter = 0;
            bool isFound = false;
            string nextBook = "";

            while (counter < libCapacity)
            {
                
                nextBook = Console.ReadLine();
                if (nextBook == favBook)
                {
                    isFound = true;
                    break;
                }
                counter++;
            }

            if (isFound == false)
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {libCapacity} books.");
            }
            else
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
