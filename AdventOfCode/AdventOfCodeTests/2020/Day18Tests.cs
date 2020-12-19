using AdventOfCode2020;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day18Tests
    {
        [Theory]
        [InlineData("2 * 3 + (4 * 5)", 26)]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public static void EvaluateExpressionLeftToRight_Calculates_CorrectResult(string expression, int expectedResult)
        {
            //Arrange

            //Act
            var actualResult = Day18.EvaluateExpression(expression, Day18.Precedence.LeftToRight);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("2 * 3 + (4 * 5)", 46)]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public static void EvaluateExpressionAddition_Calculates_CorrectResult(string expression, int expectedResult)
        {
            //Arrange

            //Act
            var actualResult = Day18.EvaluateExpression(expression, Day18.Precedence.Addition);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
