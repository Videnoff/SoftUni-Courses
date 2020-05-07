using System;
using System.Collections.Generic;

namespace P01_Custom_Doubly_Linked_List
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddFirst("Pesho" + i);
            }

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddLast("Pesho" + i);
            }

            doublyLinkedList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                doublyLinkedList.RemoveFirst();
            }

            doublyLinkedList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            Console.WriteLine(doublyLinkedList[0]);

            string[] arr = doublyLinkedList.ToArray();

            List<int> l = new List<int>();
            string str = "asdasd";
            Console.WriteLine(str[0]);

            foreach (var el in doublyLinkedList)
            {
                Console.WriteLine(el);
            }
        }
    }
}
