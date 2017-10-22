using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// Command line postfix calculator.
    /// </summary>
    /// 
    class Calculator
    {
        /**
         * The stack we are using to hold operands
         */
        private StackADT stack = new LinkedStack();
        
        /**
         * Main method. Disregards command line arguments.
         * <param name="args">The command line arguments</param>
         */
        public static void Main(String[] args)
        {
            Calculator app = new Calculator();
            bool playAgain = true;
            Console.WriteLine("\nPostfix calculator. Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = app.DoCalculation();
            }

            Console.WriteLine("Bye.");
        }

        /// <summary>
        /// Gets an input string in from the user and performs a calculation.
        /// </summary>
        /// <returns>True if the calculation was successful, false if the user quits</returns>
        private bool DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            String input = "2 2 +";
            Console.Write("> ");

            input = Console.ReadLine();

            if (input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }

            String output = "4";

            try
            {
                output = EvaluatePostFixInput(input);
            }
            catch (ArgumentOutOfRangeException e)
            {
                output = e.Message;
            }

            Console.WriteLine("\n\t>>> " + input + " = " + output);

            return true;
        }

        /// <summary>
        /// Performs the actual calculation of an expression in postfix form
        /// </summary>
        /// <param name="input">Postfix mathematical expression as a string</param>
        /// <returns>Answer as a string</returns>
        public String EvaluatePostFixInput(String input)
        {
            if (input == null || input.Equals(""))
                throw new ArgumentOutOfRangeException("Null or the empty string are not valid postfix expressions.");

            stack.Clear();

            String[] t;
            double a;
            double b;
            double c;
            double n;

            t = (input.Split());
            
            for (int i = 0; i < t.Length; i++)
            {
                bool isNumeric = double.TryParse(t[i], out n);
                if (isNumeric)
                {
                    stack.Push(n);
                }
                else
                {
                    if (t[i].Length > 1)
                        throw new ArgumentOutOfRangeException("Input Error: " + t[i] + " is not an allowed number or operator.");
                    if (stack.IsEmpty())
                        throw new ArgumentOutOfRangeException("Improper input format. Stack became empty when expecting second operand.");
                    b = ((Double)(stack.Pop()));
                    if (stack.IsEmpty())
                        throw new ArgumentOutOfRangeException("Improper input format. Stack became empty when expecting first operand.");
                    a = ((Double)(stack.Pop()));

                    c = DoOperation(a, b, t[i]);
                    stack.Push((Double)c);
                }
            }
            
            return ((Double)(stack.Pop())).ToString();
        }

        /// <summary>
        /// Perform arithmetic.
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="s">operator</param>
        /// <returns>The answer</returns>
        public Double DoOperation(double a, double b, String s)
        {
            double c = 0.0;
            if (s.Equals("+"))
                c = (a + b);
            else if (s.Equals("-"))
                c = (a - b);
            else if (s.Equals("*"))
                c = (a * b);
            else if (s.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (c == Double.NegativeInfinity || c == Double.PositiveInfinity)
         
                        throw new ArgumentOutOfRangeException("Can't divide by zero");
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentOutOfRangeException(e.Message);
                }
            }
            else
                throw new ArgumentOutOfRangeException("Improper operator: " + s + ", is not one of +, -, *, or /");

            return c;
        }

       
    }
}
