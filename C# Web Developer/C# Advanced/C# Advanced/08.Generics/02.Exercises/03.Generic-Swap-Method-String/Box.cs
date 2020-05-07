using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Generic_Swap_Method_String
{
    public class Box<T>
    {
        public List<T> Values { get; set; }

        public Box(List<T> values)
        {
            this.Values = values;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var value in this.Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }

            return sb.ToString().TrimEnd();
        }

        public void Swap(List<T> values, int firstIndex, int secondIndex)
        {
            T tempValue = values[firstIndex];
            values[firstIndex] = values[secondIndex];
            values[secondIndex] = tempValue;
        }
    }
}
