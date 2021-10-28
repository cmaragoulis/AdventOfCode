using Xunit;
using AdventOfCode2019;

namespace AdventOfCodeTests2019
{
    public class Day03Tests
    {
        [Theory]
        [InlineData("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public static void CalculateClosestIntersectionByDistance_Calculates_CorrectOutput(string wire1, string wire2, int expectedOutput)
        {
            //Arrange

            //Act
            int actualOutput = Day03.CalculateClosestIntersection(wire1, wire2, ClosestCriterion.Distance);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("R8,U5,L5,D3", "U7,R6,D4,L4", 30)]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public static void CalculateClosestIntersectionBysteps_Calculates_CorrectOutput(string wire1, string wire2, int expectedOutput)
        {
            //Arrange

            //Act
            int actualOutput = Day03.CalculateClosestIntersection(wire1, wire2, ClosestCriterion.Steps);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
