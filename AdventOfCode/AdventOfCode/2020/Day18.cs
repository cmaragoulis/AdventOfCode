using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day18
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day18.txt";

        public static long Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            long answer = 0;

            foreach (var expression in input)
            {
                answer += EvaluateExpression(expression, Precedence.LeftToRight);
            }

            return answer;
        }

        public static long Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            long answer = 0;

            foreach (var expression in input)
            {
                answer += EvaluateExpression(expression, Precedence.Addition);
            }

            return answer;
        }


        public static long EvaluateExpression(string expression, Precedence precedence)
        {
            var stack = new Stack<string>();
            var expressionStack = new Stack<string>();

            foreach (var symbol in expression.Replace(" ", string.Empty))
            {
                if (symbol != ')')
                {
                    stack.Push(symbol.ToString());
                }
                else
                {
                    while (true)
                    {
                        var poppedElement = stack.Pop();

                        if (poppedElement != "(")
                        {
                            expressionStack.Push(poppedElement);
                        }
                        else
                        {
                            break;
                        }
                    }

                    string subExpression = StackTostring(expressionStack);

                    var tempResult = CalculateExpression(subExpression, precedence);

                    stack.Push(tempResult.ToString());
                }
            }

            stack = ReverseStack(stack);
            string finalExpression = StackTostring(stack);

            return CalculateExpression(finalExpression, precedence);
        }

        private static long CalculateExpression(string expression, Precedence precedence)
        {
            long result = 0;

            switch (precedence)
            {
                case Precedence.Addition:
                    result = EvaluateAddition(expression);
                    break;
                case Precedence.LeftToRight:
                    result = EvaluateLeftToRight(expression);
                    break;
            }

            return result;
        }

        private static long EvaluateLeftToRight(string expression)
        {
            string evaluatedExpression = expression;

            while (true)
            {
                long operationResult = 0;
                var match = Regex.Match(evaluatedExpression, @"^(\d+)([+*])(\d+)(.*)$");

                if (!match.Success)
                {
                    break;
                }

                var leftOperant = long.Parse(match.Groups[1].Value);
                var operation = match.Groups[2].Value;
                var rightOperant = long.Parse(match.Groups[3].Value);

                operationResult +=
                    operation == "+"
                    ? leftOperant + rightOperant
                    : leftOperant * rightOperant;

                evaluatedExpression = $"{operationResult}{match.Groups[4].Value}";
            }

            var result = long.Parse(evaluatedExpression);

            return result;
        }

        private static long EvaluateAddition(string expression)
        {
            string evaluatedExpression = expression;

            while (true)
            {
                var match = Regex.Match(evaluatedExpression, @"(\d+)\+(\d+)");

                if (!match.Success)
                {
                    break;
                }

                var leftOperant = long.Parse(match.Groups[1].Value);
                var rightOperant = long.Parse(match.Groups[2].Value);

                var operationResult = leftOperant + rightOperant;

                var replaceRegex = new Regex($@"{leftOperant}\+{rightOperant}");
                evaluatedExpression = replaceRegex.Replace(evaluatedExpression, $"{operationResult}", 1);
            }

            var result = EvaluateLeftToRight(evaluatedExpression);

            return result;
        }

        private static Stack<T> ReverseStack<T>(Stack<T> stack)
        {
            var reversedStack = new Stack<T>();

            while (stack.Count > 0)
            {
                reversedStack.Push(stack.Pop());
            }

            return reversedStack;
        }

        private static string StackTostring<T>(Stack<T> stack)
        {
            var str = string.Empty;

            while(stack.Count > 0)
            {
                str += stack.Pop();
            }

            return str;
        }

        public enum Precedence
        {
            Addition,
            LeftToRight
        }
    }
}
