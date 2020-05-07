using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Create_Custom_Data_Structures
{
    public class MyList
    {

        private int capacity;
        private int[] data;

        public MyList() : this(4)
        {
        }

        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new int[capacity];
        }

        public int Count { get; private set; }

        public void Add(int number)
        {
            this.data[this.Count] = number;
            this.Count++;
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new int[capacity];
        }
    }
}
