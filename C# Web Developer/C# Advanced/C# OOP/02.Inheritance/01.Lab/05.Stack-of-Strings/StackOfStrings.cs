using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Stack_of_Strings
{
    public class StackOfStrings : Stack<string>
    {
        public bool isEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                this.Push(value);
            }
        }
    }
}
