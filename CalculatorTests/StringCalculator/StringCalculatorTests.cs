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
            //Arrange
            var testExprestion = "";

            //Act 
            var result = _calculator.Add(testExprestion);

            //Assert
            Assert.Equal(0, result);
        }
        [Fact]
        public void Add_OneNum_ShouldBeEqualSum()
        {
            //Arrange
            var testExprestion = "1";

            //Act 
            var result = _calculator.Add(testExprestion);

            //Assert
            Assert.Equal(1, result);
        }
        [Fact]
        public void Add_NumsWithOneDelimiter_ShouldBeEqualSum()
        {
            //Arrange
            var testExprestion = "1,2,3";

            //Act 
            var result = _calculator.Add(testExprestion);

            //Assert
            Assert.Equal(6, result);
        }
        [Fact]
        public void Add_NumsWithMultipleDelimiter_ShouldBeEqualSum()
        {
            //Arrange
            var testExprestion = "1,2\n3";

            //Act 
            var result = _calculator.Add(testExprestion);

            //Assert
            Assert.Equal(6, result);
        }
        [Fact]
        public void Add_NumsWithCustomDelimiter_ShouldBeEqualSum()
        {
            //Arrange
            var testExprestion = "//;\n1;2;3";

            //Act 
            var result = _calculator.Add(testExprestion);

            //Assert
            Assert.Equal(6, result);
        }
        [Fact]
        public void Add_NegativeNums_ShouldThrowException()
        {

            //Arrange
            var testExprestion = "//;\n-1;-2;-3";

            //Act 
            //Assert
            Assert.Throws<Exception>(() => _calculator.Add(testExprestion));
        }
    }
}