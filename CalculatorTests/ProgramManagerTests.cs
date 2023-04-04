using StringCalculator.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace StringCalculator.Logic.Tests
{
    public class ProgramManagerTests
    {
        private Mock<IConsoleManager> _console;
        private Mock<IProgramManager> _programManager;
        public ProgramManagerTests()
        {
            _console = new Mock<IConsoleManager>();
            _programManager = new Mock<ProgramManager>();
        }
        
    }
}
