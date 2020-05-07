using System;
using System.Collections.Generic;

namespace _05.Generic_Count_Method_String
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> value)
        {
            this.Values = value;
        }

        public List<T> Values { get; set; }

        public int CountGreaterElements(List<T> elements, T elementToCompare)
        {
            int counter = 0;

            foreach (var element in elements)
            {
                if (elementToCompare.CompareTo(element) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
