using AdventOfCode2019;
using Xunit;

namespace AdventOfCodeTests2019
{
    public class Day04Tests
    {
        [Theory]
        [InlineData(111111, true)]
        [InlineData(122345, true)]
        [InlineData(111123, true)]
        [InlineData(135679, false)]
        [InlineData(223450, false)]
        [InlineData(123789, false)]
        [InlineData(99999, false)]
        [InlineData(1234567, false)]
        public static void IsValidPassword_Returns_CorrectResults(int password, bool expectedValidity)
        {
            //Arrange

            //Act
            var actualValidity = Day04.IsValidPassword(password);

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }

        [Theory]
        [InlineData(112233, true)]
        [InlineData(111122, true)]
        [InlineData(223334, true)]
        [InlineData(123444, false)]
        [InlineData(12344, false)]
        [InlineData(1234445, false)]

        public static void IsValidPassword2_Returns_CorrectResults(int password, bool expectedValidity)
        {
            //Arrange

            //Act
            var actualValidity = Day04.IsValidPassword2(password);

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }
    }
}
