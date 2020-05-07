using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Custom_Doubly_Linked_List
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PreviousNode { get; set; }
    }
}
