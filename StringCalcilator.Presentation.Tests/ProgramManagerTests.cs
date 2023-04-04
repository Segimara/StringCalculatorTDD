using Moq;
using Xunit;

namespace StringCalculator.Presentation.Tests
{
    public class ProgramManagerTests
    {
        private Mock<ConsoleManager> _consoleMock;
        private Mock<Logic.StringCalculator> _calculatorMock;
        private Program _program;
        public ProgramManagerTests()
        {
            _consoleMock = new Mock<ConsoleManager>();
            _calculatorMock = new Mock<Logic.StringCalculator>();
            _program = new Program(_consoleMock.Object, _calculatorMock.Object);
        }
        [Fact]
        public void Run_SequenceOfInputs_ShouldCorrectOutput()
        {
            // Arrange
            var program = new Program(_consoleMock.Object, _calculatorMock.Object);

            _calculatorMock.Setup(c => c.Add("1,2,3")).Returns(6);
            _calculatorMock.Setup(c => c.Add("4,5,6")).Returns(15);

            _consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1,2,3")
                .Returns("4,5,6")
                .Returns("");

            // Act
            program.Run();

            // Assert
            _consoleMock.Verify(c => c.WriteLine("Enter comma separated numbers (enter to exit):"), Times.Once());
            _calculatorMock.Verify(c => c.Add("1,2,3"), Times.Once());
            _calculatorMock.Verify(c => c.Add("4,5,6"), Times.Once());
            _consoleMock.Verify(c => c.WriteLine("Result is: 6"), Times.Once());
            _consoleMock.Verify(c => c.WriteLine("Result is: 15"), Times.Once());
            _consoleMock.Verify(c => c.WriteLine("you can enter other numbers (enter to exit)?"), Times.Exactly(2));
        }
        [Fact]
        public void Run_ImmediateExit_ShouldBeOneOutputs()
        {
            // Arrange
            var program = new Program(_consoleMock.Object, _calculatorMock.Object);

            _consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("");

            // Act
            program.Run();

            // Assert
            _consoleMock.Verify(c => c.WriteLine("Enter comma separated numbers (enter to exit):"), Times.Once());
        }
    }
}
