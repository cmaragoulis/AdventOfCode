using AdventOfCode2020;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day08Tests
    {
        [Fact]
        public static void ExecuteProgram_Outputs_CorrectResult()
        {
            //Arrange
            var input = new string[] {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
            };
            var program = Day08.ParseInput(input);
            var expectedOutput = 5;

            //Act
            var actualOutput = Day08.ExecuteProgram(program);

            //Asser
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public static void FixCorruptProgram_Outputs_CorrectResult()
        {
            //Arrange
            var input = new string[] {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
            };
            var program = Day08.ParseInput(input);
            var expectedOutput = 8;

            //Act
            Day08.FixCorruptProgram(program);
            var actualOutput = Day08.ExecuteProgram(program);

            //Asser
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
