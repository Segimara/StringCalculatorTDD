using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculator.Logic.Interfaces;

namespace StringCalculator.Logic
{
    public class ProgramManager : IProgramManager
    {
        public ICalculator Calculator { get; set; }
        public IConsoleManager ConsoleManager { get; }
        public ProgramManager(IConsoleManager consoleManager, ICalculator calculator)
        {
            ConsoleManager = consoleManager;
            Calculator = calculator;
        }
        public void Run()
        {
            while (true)
            {
                PrintMenu();
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                ExecuteAndGetResult(input, Calculator);
            }
        }
        void PrintMenu()
        {
            Console.WriteLine("Enter comma separated numbers (enter to exit):");
        }

        private void ExecuteAndGetResult(string input, ICalculator calculator)
        {
            var result = calculator.Add(input);
            Console.WriteLine($"Result is: {result}");

            PrintMenu();
        }
    }
}
