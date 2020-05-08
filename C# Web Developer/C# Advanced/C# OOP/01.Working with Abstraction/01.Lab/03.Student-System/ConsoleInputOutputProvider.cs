using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class ConsoleInputOutputProvider : IInputOutputProvider
    {
        public string GetInput() => Console.ReadLine();

        public void ShowOutput(string data) => Console.WriteLine(data);
    }
}
