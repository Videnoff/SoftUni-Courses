using System.Linq;
using _03.Telephony.Contracts;
using _03.Telephony.Exceptions;

namespace _03.Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {
            
        }

        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}