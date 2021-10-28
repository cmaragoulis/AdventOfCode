using AdventOfCode2019;
using Xunit;

namespace AdventOfCodeTests2019
{
    public class Day02Tests
    {
        [Theory]
        [InlineData("1,9,10,3,2,3,11,0,99,30,40,50", "3500,9,10,70,2,3,11,0,99,30,40,50")]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void ExecuteProgram_Produces_ExpectedOutput(string input, string expectedOutput)
        {
            // Arrange

            // Act
            var actualOutput = string.Join(',', Day02.ExecuteProgram(input));

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
