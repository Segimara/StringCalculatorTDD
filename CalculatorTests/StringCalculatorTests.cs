using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using StringCalculator.Logic.Exceptions;
using Xunit;

namespace StringCalculator.Logic.Tests
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _calculator;
        public StringCalculatorTests()
        {
            _calculator = new StringCalculator();
        }
        [Fact]
        public void Add_EmptyString_ShouldBeEqualZero()
        {
            //Act 
            var result = _calculator.Add("");

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_OneNumber_ShouldBeEqualSumOfNumbers()
        {
            //Act 
            var result = _calculator.Add("1");

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_NumbersWithMultipleDelimiter_ShouldBeEqualSumOfNumbers()
        {
            //Arrange
            var result = _calculator.Add(@"1,2\n3");

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_NumbersWithCustomDelimiter_ShouldBeEqualSumOfNumbers()
        {
            //Arrange
            var result = _calculator.Add(@"//;\n1;2;3");

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_NumbersWithMultipleNegativeNumbers_ShouldThrowException()
        {

            //Arrange
            //Act 
            //Assert
            var exception = Assert.Throws<NegativeNumberException>(() => _calculator.Add(@"//;\n1;-2;-3"));
            Assert.Equal("negatives not allowed\n Numbers: -2,-3", exception.Message);
        }

        [Fact]
        public void Add_NumbersBigerThenThousand_ShouldSkipNumberBiggerThenThousand()
        {
            //Arrange
            var result = _calculator.Add(@"//;\n1;1001");

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_NumbersWithMultipleCustomDelimiters_ShouldBeEqualSumOfNumbers()
        {
            //Arrange
            var result = _calculator.Add(@"//[;][%]\n1;2%3");

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_NumbersWithMultipleCustomDelimitersLongenThanOneChar_ShouldBeEqualSumOfNumbers()
        {
            //Arrange
            var result = _calculator.Add(@"//[;#][%*]\n1;#2%*3");

            //Assert
            Assert.Equal(6, result);
        }
    }
}