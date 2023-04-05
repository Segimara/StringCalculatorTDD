using Moq;
using Xunit;

namespace StringCalculator.Presentation.Tests
{
    public class CalculatorApplicationTests
    {
        private Mock<ConsoleManager> _consoleMock;
        private Mock<Logic.StringCalculator> _calculatorMock;
        private CalculatorApplication _application;

        public CalculatorApplicationTests()
        {
            _consoleMock = new Mock<ConsoleManager>();
            _calculatorMock = new Mock<Logic.StringCalculator>();
            _application = new CalculatorApplication(_consoleMock.Object, _calculatorMock.Object);
        }

        [Fact]
        public void Run_ImmediateExit_ShouldBeOneOutputs()
        {

            _consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("");

            // Act
            _application.Run();

            // Assert
            _consoleMock.Verify(c => c.WriteLine("Enter comma separated numbers (enter to exit):"), Times.Once());
        }

        [Fact]
        public void Run_SequenceOfInputs_ShouldOutputMessageAfterSomeInput()
        {
            _calculatorMock.Setup(c => c.Add("1,2,3")).Returns(6);

            _consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1,2,3")
                .Returns("1,2,3")
                .Returns("");

            // Act
            _application.Run();

            // Assert
            _consoleMock.Verify(c => c.WriteLine("Enter comma separated numbers (enter to exit):"), Times.Once());
            _consoleMock.Verify(c => c.WriteLine("you can enter other numbers (enter to exit)?"), Times.Exactly(2));
        }

        [Fact]
        public void Run_SequenceOfInputs_ShouldOutputCorrectResultMultipleTimes()
        {
            _calculatorMock.Setup(c => c.Add("1,2,3")).Returns(6);

            _consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1,2,3")
                .Returns("1,2,3")
                .Returns("");

            // Act
            _application.Run();

            // Assert
            _consoleMock.Verify(c => c.WriteLine("Enter comma separated numbers (enter to exit):"), Times.Once());
            _calculatorMock.Verify(c => c.Add("1,2,3"), Times.Exactly(2));
            _consoleMock.Verify(c => c.WriteLine("Result is: 6"), Times.Exactly(2));

        }
    }
}
