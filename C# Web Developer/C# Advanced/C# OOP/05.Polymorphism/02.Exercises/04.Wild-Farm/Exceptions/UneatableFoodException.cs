using System;

namespace _04.Wild_Farm.Exceptions
{
    public class UneatableFoodException : Exception
    {
        public UneatableFoodException(string? message) : base(message)
        {

        }
    }
}