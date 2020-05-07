using System;

namespace P01_Create_Custom_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList();

            list.Add(10);
            list.Add(20);
            list.Add(30);

            var count = list.Count;

            Console.WriteLine(count);

            list.Clear();

            Console.WriteLine(list.Count);
        }
    }
}
