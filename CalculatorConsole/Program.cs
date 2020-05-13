using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace CalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Stack<object> stack = new Stack<object>();
            Stack<object> revStack = new Stack<object>();
            string input, operand;
            double num1, num2, tempNum;
            const string operators = "+-*/";

            Console.WriteLine("Welcome to the Calculator App!");
            Console.WriteLine("Enter your equation OR type EXIT to leave. Please put a space between each character you enter.");
            do
            {
                input = Console.ReadLine();

                if (input.ToUpper() == "EXIT")
                {
                    return;
                }

                string[] inputArr = input.Split();

                foreach (var str in inputArr)
                {
                    if (str.Length == 0)
                        continue;
                    if (double.TryParse(str, out tempNum))
                    {
                        stack.Push(tempNum);
                    }
                    else
                    {
                        if (operators.Contains(str))
                        {
                            stack.Push(str);
                        }
                    }
                }

                while (stack.Count > 0)
                {
                    revStack.Push(stack.Pop());
                }

                stack = revStack;

                double.TryParse(stack.Pop().ToString(), out num1);

                while (stack.Count > 0)
                {
                    operand = stack.Pop().ToString();
                    double.TryParse(stack.Pop().ToString(), out num2);

                    num1 = calculator.Arithmetic(num1, operand, num2);
                }

                Console.WriteLine($"= {num1}");
                Console.WriteLine();
                Console.WriteLine("Are you finished? Y/N");
                input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    input = "EXIT";
                }

            } while (input.ToUpper() != "EXIT");

        }
    }
}
