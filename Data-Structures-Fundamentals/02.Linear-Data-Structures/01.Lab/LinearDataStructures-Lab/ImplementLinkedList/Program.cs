namespace ImplementLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            global::ImplementLinkedList.LinkedList<int> linkedList = new global::ImplementLinkedList.LinkedList<int>();
            for (int i = 0; i < 11; i++)
            {
                linkedList.Add(i);
            }
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i);
            }


            //Console.WriteLine($"Removed: {linkedList.RemoveHead().Value}");
            //Console.WriteLine($"Removed: {linkedList.RemoveHead().Value}");
            //Console.WriteLine($"Removed: {linkedList.RemoveHead().Value}");

            var currentNode = linkedList.Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }

            Console.WriteLine($"Head is: {linkedList.Head.Value}");
            Console.WriteLine($"Last is: {linkedList.Last.Value}");
        }
    }
}
