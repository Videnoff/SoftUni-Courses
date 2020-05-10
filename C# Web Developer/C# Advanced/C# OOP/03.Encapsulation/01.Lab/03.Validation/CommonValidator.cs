using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class CommonValidator
    {
        public static void ValidateNull(object value, string typeName, string propertyName)
        {
            if (value == null)
            {
                throw new NullReferenceException($"{typeName}.{propertyName} cannot be null.");
            }
        }

        public static void ValidateMinimum<T>(T value, T minimum, string typeName, string propertyName)where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0)
            {
                throw new ArgumentOutOfRangeException($"{typeName}.{propertyName} cannot be less than {minimum}");
            }
        }

        public static void ValidateLength(string text, int minimumLength, string typeName, string propertyName)
        {
            ValidateNull(text, typeName, propertyName);
            ValidateMinimum(text.Length, minimumLength, typeName, propertyName);
        }
    }
}
