﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;

        public Box()
        {
            this.items = new List<T>();
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public T Remove()
        {
            var item = this.items[items.Count - 1];
            this.items.RemoveAt(items.Count - 1);

            return item;
        }
    }
}
