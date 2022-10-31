using System.Linq.Expressions;
using System.Windows.Forms;

namespace Calculator.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("2+2*2", "6")]
        [InlineData("2/0", "NOT / 0")]
        [InlineData("", null)]
        public void GetResult_Test(string expression, string expected)
        {
            // Arrange
            Logic logic = new();

            // Act
            string actual = logic.GetResult(expression);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2", "-2")]
        [InlineData("0", "0")]
        public void NegateNumber_Test(string number, string expected)
        {
            // Arrange
            Logic logic = new();

            // Act
            string actual = logic.NegateNumber(number);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}