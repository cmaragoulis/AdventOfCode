using AdventOfCode2020;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day10Tests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public static void FindDistributionOfAdapters_Returns_CorrectResult(
            List<int> adapters, int expectedAnswer)
        {
            //Arrange


            //Act
            var actualAnswer = Day10.FindDistributionOfAdapters(adapters);

            //Assert
            Assert.Equal(expectedAnswer, actualAnswer);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                new List<int> { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 },
                35
            };

            yield return new object[]
{
                new List<int> { 28,33,18,42,31,14,46,20,48,47,24,23,49,45,19,38,39,11,1,32,25,35,8,17,7,9,4,2,34,10,3 },
                220
            };
        }

        [Theory]
        [MemberData(nameof(GetTestData2))]
        public static void CalculatePermutations_Returns_CorrectResult(List<int> adapters, int expectedResult)
        {
            //Arrange


            //Act
            var actualResult = Day10.CalculatePermutations(adapters);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        public static IEnumerable<object[]> GetTestData2()
        {
            yield return new object[]
            {
                new List<int> { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 },
                8
            };

            yield return new object[]
{
                new List<int> { 28,33,18,42,31,14,46,20,48,47,24,23,49,45,19,38,39,11,1,32,25,35,8,17,7,9,4,2,34,10,3 },
                19208
            };
        }
    }
}
