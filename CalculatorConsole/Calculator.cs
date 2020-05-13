using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorConsole
{
    public class Calculator
    {
        public double Arithmetic(double num1, string operand, double num2)
        {
            switch(operand)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num2 != 0 ? num1 / num2 : 0;
                default:
                    return 0;
            }
        }

    }
}
