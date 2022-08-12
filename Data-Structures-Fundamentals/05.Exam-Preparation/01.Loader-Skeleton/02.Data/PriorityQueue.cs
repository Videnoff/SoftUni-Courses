using System.Collections.Generic;

namespace _02.Data
{
    using System;

    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
        }

        public List<T> GetAsList
        {
            get
            {
                return heap;
            }
        }

        public int Size
        {
            get { return heap.Count; }
        }

        public T Peek()
        {
            return heap[0];
        }

        public T Dequeue()
        {
            T top = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            HeapifyDown(0);

            return top;
        }

        private void HeapifyDown(int index)
        {
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;
            var maxChildIndex = leftChildIndex;

            if (leftChildIndex >= heap.Count)
            {
                return;
            }

            if ((rightChildIndex < heap.Count) && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (heap[index].CompareTo(heap[maxChildIndex]) < 0)
            {
                // Swap
                (heap[index], heap[maxChildIndex]) = (heap[maxChildIndex], heap[index]);

                HeapifyDown(maxChildIndex);
            }
        }

        public void Add(T element)
        {
            heap.Add(element);
            Heapify(heap.Count - 1);
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                // Swap
                (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
                Heapify(parentIndex);
            }
        }
    }
}