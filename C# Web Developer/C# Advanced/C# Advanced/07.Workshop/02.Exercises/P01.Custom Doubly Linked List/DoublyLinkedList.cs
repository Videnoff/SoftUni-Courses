using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P01_Custom_Doubly_Linked_List
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;

        private ListNode<T> tail;

        public T this[int index]
        {
            get
            {
                T[] arr = this.ToArray();

                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Index out of the bounds of the list!", nameof(index));    
                }

                return arr[index];
            }
        }

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                ListNode<T> oldHead = this.head;

                this.head = newHead;
                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                ListNode<T> oldTail = this.tail;

                this.tail = newTail;
                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {

            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            T removedEl = this.head.Value;

            
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newHead = this.head.NextNode;
                newHead.PreviousNode = null;
                this.head = newHead;
            }

            this.Count--;

            return removedEl;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            T removedEl = this.tail.Value;

            
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newTail = this.tail.PreviousNode;
                newTail.NextNode = tail;
                this.tail = newTail;
            }

            this.Count--;

            return removedEl;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentEl = this.head;

            while (currentEl != null)
            {
                action(currentEl.Value);
                currentEl = currentEl.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];

            int cnt = 0;

            ListNode<T> currentEl = this.head;

            while (currentEl != null)
            {
                arr[cnt++] = currentEl.Value;
                currentEl = currentEl.NextNode;
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            /*
             * Logic for looping
             */
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
