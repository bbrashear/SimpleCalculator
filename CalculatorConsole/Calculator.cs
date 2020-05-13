using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorConsole
{
    public class Calculator
    {
        public double Arithmetic(double num1, string operand, double num2)
        {
            double answer = 0;
            switch(operand)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num2 != 0 ? answer = num1 / num2 : 0;
                default:
                    return answer = 0;
            }
        }

    }
}
