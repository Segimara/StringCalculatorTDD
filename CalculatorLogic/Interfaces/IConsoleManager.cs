using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Logic.Interfaces
{
    public interface IConsoleManager
    {
        void Write(string value);
        void WriteLine(string value);
        string ReadLine();
    }
}
