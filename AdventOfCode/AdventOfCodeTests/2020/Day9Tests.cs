using AdventOfCode2020;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day9Tests
    {
        [Fact]
        public static void FindWeakNumber_Finds_CorrectResult()
        {
            //Arrange
            var numbers = new List<long>()
            {
                35,20,15,25,47,40,62,55,65,95,102,117,150,182,127,219,299,277,309,576
            };
            int preamble = 5;
            var expectedAnswer = 127;

            //Act
            var actualAnswer = Day9.FindWeakNumber(preamble, numbers);

            //Assert
            Assert.Equal(expectedAnswer, actualAnswer);
        }

        [Fact]
        public static void FindEncryptionWeakness_Finds_CorrectResult()
        {
            //Arrange
            var numbers = new List<long>()
            {
                35,20,15,25,47,40,62,55,65,95,102,117,150,182,127,219,299,277,309,576
            };
            int weakNumber = 127;
            var expectedAnswer = 62;

            //Act
            var actualAnswer = Day9.FindEncryptionWeakness(numbers, weakNumber);

            //Assert
            Assert.Equal(expectedAnswer, actualAnswer);
        }
    }
}
