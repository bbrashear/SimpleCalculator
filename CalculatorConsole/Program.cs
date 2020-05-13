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
            //instantiation of objects and declaration of variables
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
                //takes user input
                input = Console.ReadLine();

                //controls for case and determines if user would like to leave
                if (input.ToUpper() == "EXIT")
                {
                    return;
                }

                //splits input on spaces and stores in an array
                string[] inputArr = input.Split();

                //loops through array
                foreach (var str in inputArr)
                {
                    //if empty, continues to the next element
                    if (str.Length == 0)
                        continue;
                    //parses a double, stores in variable, and pushes to the stack
                    if (double.TryParse(str, out tempNum))
                    {
                        stack.Push(tempNum);
                    }
                    else
                    {
                        //finds if next object is an operator and pushes to the stack
                        if (operators.Contains(str))
                        {
                            stack.Push(str);
                        }
                    }
                }

                //since stack if FILO, pops last item off the stack and pushes it into revStack while there are still elements in the stack
                while (stack.Count > 0)
                {
                    revStack.Push(stack.Pop());
                }

                //reassigns the stack to revStack so objects come out in correct order
                stack = revStack;

                //parses the first object off the stack and stores it into num1
                double.TryParse(stack.Pop().ToString(), out num1);

                while (stack.Count > 0)
                {
                    //stores the next object off the stack, which should be an operator into operand
                    operand = stack.Pop().ToString();
                    //parses the next object off the stack and stores it into num2
                    double.TryParse(stack.Pop().ToString(), out num2);
                    //uses method from calculator class to perform arithmetic operation and store back into num1 in case there are more objects
                    num1 = calculator.Arithmetic(num1, operand, num2);
                }

                Console.WriteLine($"= {num1}");
                Console.WriteLine();
                //asks user if they are finished and either exits or starts over app
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
