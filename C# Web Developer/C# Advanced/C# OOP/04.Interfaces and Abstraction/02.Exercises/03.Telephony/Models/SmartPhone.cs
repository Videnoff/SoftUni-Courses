using System.Linq;
using _03.Telephony.Contracts;
using _03.Telephony.Exceptions;

namespace _03.Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidUrlException();
            }

            return $"Browsing: {url}!";
        }
    }
}