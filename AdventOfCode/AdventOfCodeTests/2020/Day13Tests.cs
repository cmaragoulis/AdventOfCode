using AdventOfCode2020;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day13Tests
    {
        [Theory]
        [InlineData("7,13,x,x,59,x,31,19", 1068781)]
        [InlineData("17,x,13,19", 3417)]
        [InlineData("67,7,59,61", 754018)]
        [InlineData("67,x,7,59,61", 779210)]
        [InlineData("67,7,x,59,61", 1261476)]
        [InlineData("1789,37,47,1889", 1202161486)]
        public static void FindEarliestTimestampForContest_Returns_CorrectResult(string buses, long expecteAnswer)
        {
            //Arrange

            //Act
            var actualAnswer = Day13.FindEarliestTimestampForContest(buses);

            //Assert
            Assert.Equal(expecteAnswer, actualAnswer);
        }

        [Theory]
        [InlineData("7,13,x,x,59,x,31,19", 1068781)]
        [InlineData("17,x,13,19", 3417)]
        [InlineData("67,7,59,61", 754018)]
        [InlineData("67,x,7,59,61", 779210)]
        [InlineData("67,7,x,59,61", 1261476)]
        [InlineData("1789,37,47,1889", 1202161486)]
        public static void FindEarliestTimestampForContestBruteForce_Returns_CorrectResult(string buses, long expecteAnswer)
        {
            //Arrange

            //Act
            var actualAnswer = Day13.FindEarliestTimestampForContestBruteForce(buses);

            //Assert
            Assert.Equal(expecteAnswer, actualAnswer);
        }
    }
}
