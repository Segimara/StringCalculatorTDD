using StringCalculator.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculator.Logic.Tests
{
    public class ProgramManagerTests
    {
        private IConsoleManager _console;
        private IProgramManager _programManager;
        public ProgramManagerTests()
        {
            var moq = new Mock<IConsoleManager>();
        }
        [Fact]
        public void 
    }
}
