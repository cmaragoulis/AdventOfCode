using AdventOfCode2020;
using System.Linq;
using Xunit;

namespace AdventOfCodeTests._2020
{
    public class Day15Tests
    {
        [Theory]
        [InlineData("0,3,6", 436)]
        [InlineData("1,3,2", 1)]
        [InlineData("2,1,3", 10)]
        [InlineData("1,2,3", 27)]
        [InlineData("2,3,1", 78)]
        [InlineData("3,2,1", 438)]
        [InlineData("3,1,2", 1836)]
        public static void PlayMemoryGame_ReturnCorrectResult(string numbers, int expectedResult)
        {
            //Arrange
            int rounds = 2020;
            var startinNumbers = numbers.Split(',').Select(n => int.Parse(n)).ToList();

            //Act
            var actualResult = Day15.PlayMemoryGame(startinNumbers, rounds);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
