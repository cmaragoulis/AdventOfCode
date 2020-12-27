using AdventOfCode2020;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCodeTests2020
{

    public class Day22Tests
    {
        [Fact]
        public static void Combat_Returns_CorrectWinninHand()
        {
            //Arrange
            var player1 = new List<int> { 9, 2, 6, 3, 1 };
            var player2 = new List<int> { 5, 8, 4, 7, 10 };
            var expectedWinningHand = new List<int>
            {
                3, 2, 10, 6, 8, 5, 9, 4, 7, 1
            };
            long expectedWinningScore = 306;

            //Act
            var actualWinningHand = Day22.Combat(player1, player2);
            var actualWinningScore = Day22.CalculateWinnerScore(actualWinningHand);

            //Assert
            Assert.Equal(expectedWinningHand, actualWinningHand);
            Assert.Equal(expectedWinningScore, actualWinningScore);
        }
    }
}
