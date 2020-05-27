using System;

namespace DataTypeFinder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                bool isInteger = int.TryParse(command, out int intValue);
                bool isDouble = double.TryParse(command, out double doubleValue);
                bool isChar = char.TryParse(command, out char charValue);
                bool isBool = bool.TryParse(command, out bool boolValue);

                string dataType = "";

                if (isInteger)
                {
                    dataType = "integer";
                }
                else if (isDouble)
                {
                    dataType = "floating point";
                }
                else if (isChar)
                {
                    dataType = "character";
                }
                else if (isBool)
                {
                    dataType = "boolean";
                }
                else
                {
                    dataType = "string";
                }
                Console.WriteLine($"{command} is {dataType} type");
                command = Console.ReadLine();
            }
        }
    }
}
