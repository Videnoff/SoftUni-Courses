using System;
using System.Globalization;
using _01.Logger.Common;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;
using _01.Logger.Models.Errors;

namespace _01.Logger.Factories
{
    public class ErrorFactory
    {

        public IError ProduceError(string dateStr, string message, string levelStr)
        {

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateStr, GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid date format!", e);
            }

            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelStr, true, out level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            IError error = new Error(dateTime, message, level);

            return error;
        }
    }
}