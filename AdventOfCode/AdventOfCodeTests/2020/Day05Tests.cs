using AdventOfCode2020;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day05Tests
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void DecodeBoardingPass_Correctly_DecodesSeatId(string boardingPass, int expectedSeatId)
        {
            //Arrange

            //Act
            var actualSeatId = Day05.DecodeBoardingPass(boardingPass);

            //Assert
            Assert.Equal(expectedSeatId, actualSeatId);
        }
    }
}
