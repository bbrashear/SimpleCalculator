using System;
using Xunit;
using CalculatorConsole;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add()
        {
            double sum = 0;
            double num1 = 1;
            double num2 = 1;

            sum = num1 + num2;
            Assert.Equal(2, sum);
        }

        [Theory]
        [InlineData(2, "+", 2, 4)]
        [InlineData(10, "-", 0, 10)]
        [InlineData(2, "*", -4, -8)]
        [InlineData(16, "/", 4, 4)]
        [InlineData(16, "/", 0, 0)]

        public void Arithmetic(double num1, string operand, double num2, double expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var actual = sut.Arithmetic(num1, operand, num2);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
