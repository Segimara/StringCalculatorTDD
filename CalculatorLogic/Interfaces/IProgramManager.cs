using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Logic.Interfaces
{
    public interface IProgramManager
    {
        IConsoleManager ConsoleManager { get; }
        ICalculator Calculator { get; }
        void Run();
    }
}
