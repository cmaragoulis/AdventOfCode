using AdventOfCode2020;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day25Tests
    {
        [Theory]
        [InlineData(7, 5764801, 8)]
        [InlineData(7, 17807724, 11)]
        public static void DetermineLoopSize_Returns_CorrectResult(
            int subject, int publicKey, long expectedLoopSize)
        {
            //Arrange

            //Act
            var actualLoopSize = Day25.DetermineLoopSize(subject, publicKey);

            //Assert
            Assert.Equal(expectedLoopSize, actualLoopSize);
        }
    }
}
