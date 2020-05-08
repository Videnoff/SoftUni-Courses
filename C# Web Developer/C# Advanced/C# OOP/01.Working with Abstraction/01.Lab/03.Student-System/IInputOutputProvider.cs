using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public interface IInputOutputProvider
    {
        string GetInput();

        void ShowOutput(string data);
    }
}
