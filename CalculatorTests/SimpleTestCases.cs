using test_first_manner;
using Xunit;

namespace CalculatorTests
{
    public class SimpleTestCases
    {
        [Fact]
        public void ZeroNums_0()
        {
            //Arrenge
            StringCalculator calculator = new StringCalculator();
            var testExprestion = "";
            //Act 
            var result = calculator.Add(testExprestion);
            //Assert
            Assert.Equal(0, result);
        }
        [Fact]
        public void OneNum_1()
        {
            //Arrenge
            StringCalculator calculator = new StringCalculator();
            var testExprestion = "1";
            //Act 
            var result = calculator.Add(testExprestion);
            //Assert
            Assert.Equal(1, result);
        }
        [Fact]
        public void TwoNums_3()
        {
            //Arrenge
            StringCalculator calculator = new StringCalculator();
            var testExprestion = "1,2";
            //Act 
            var result = calculator.Add(testExprestion);
            //Assert
            Assert.Equal(3, result);
        }
        [Fact]
        public void SevenNumbers_7()
        {
            //Arrenge
            StringCalculator calculator = new StringCalculator();
            var testExprestion = "1,1,1,1,1,1,1";
            //Act 
            var result = calculator.Add(testExprestion);
            //Assert
            Assert.Equal(7, result);
        }
        [Fact]
        public void SevenNumbersWithNewLineDelimeter_7()
        {
            //Arrenge
            StringCalculator calculator = new StringCalculator();
            var testExprestion = "1,1\n1\n1,1\n1,1";
            //Act 
            var result = calculator.Add(testExprestion);
            //Assert
            Assert.Equal(7, result);
        }
    }
}