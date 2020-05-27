using System;

namespace Elevator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = persons / capacity;
            int extra = persons % capacity;

            if (extra != 0)
            {
                courses++;
            }
            Console.WriteLine(courses);
        }
    }
}
