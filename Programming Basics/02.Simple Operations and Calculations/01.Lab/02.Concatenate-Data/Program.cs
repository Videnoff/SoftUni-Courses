using System;

namespace ConcatenateData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int years = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();

            Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}.", firstName, lastName, years, town);
        }
    }
}
