using AdventOfCode2020;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day14Tests
    {
        [Fact]
        public static void ExecuteProgram_Calculates_CorrectResult()
        {
            //Arrange
            var program = new string[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };
            var expectedResult = 165;

            //Act
            var actualResult = Day14.ExecuteProgram(program);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public static void ExecuteProgramV2_Calculates_CorrectResult()
        {
            //Arrange
            var program = new string[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            };
            var expectedResult = 208;

            //Act
            var actualResult = Day14.ExecuteProgramV2(program);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public static void GenerateAddresses_Calculates_CorrectResult()
        {
            //Arrange
            var maskedAddress = "000000000000000000000000000000X1101X";
            var expectedResult = new List<string>()
            {
                "000000000000000000000000000000011010",
                "000000000000000000000000000000011011",
                "000000000000000000000000000000111010",
                "000000000000000000000000000000111011"
            };


            //Act
            var actualResult = Day14.GenerateAddresses(maskedAddress);

            //Assert
            Assert.True(expectedResult.SequenceEqual(actualResult));
        }
    }
}
