using System;

namespace Login
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            string userInput = "";
            int counter = 0;

            for (int i = username.Length - 1; i >= 0; --i)
            {
                password += username[i];
            }

            while ((userInput = Console.ReadLine()) != password)
            {
                if (userInput != password)
                {
                    if (counter == 3)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                    Console.WriteLine($"Incorrect password. Try again.");
                    counter++;
                }
            }
            if (userInput == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}