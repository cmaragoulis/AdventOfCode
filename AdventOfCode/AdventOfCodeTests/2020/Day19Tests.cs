using AdventOfCode2020;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day19Tests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public static void BuildMasterRule_BuildsRule_Correctly(Dictionary<int, string> rules, string expectedMasterRule)
        {
            //Arrange

            //Act
            var actualMasterRule = Day19.BuildMasterRule(rules);

            //Assert
            Assert.Equal(expectedMasterRule, actualMasterRule);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                new Dictionary<int, string> {
                    { 0, "1 2" },
                    { 1, "a" },
                    { 2, "1 3 | 3 1" },
                    { 3, "b"}
                },
                "^a(ab|ba)$"
            };

            yield return new object[]
            {
                new Dictionary<int, string> {
                    { 0, "4 1 5" },
                    { 1, "2 3 | 3 2" },
                    { 2, "4 4 | 5 5" },
                    { 3, "4 5 | 5 4"},
                    { 4, "a"},
                    { 5, "b" }
                },
                "^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$"
            };
        }

        [Theory]
        [InlineData("^a(ab|ba)$", "aab", true)]
        [InlineData("^a(ab|ba)$", "baab", false)]
        [InlineData("^a(ab|ba)$", "aaab", false)]
        [InlineData("^a(ab|ba)$", "aaba", false)]
        [InlineData("^a(ab|ba)$", "aabb", false)]
        [InlineData("^a(ab|ba)$", "aba", true)]
        [InlineData("^a(ab|ba)$", "abaa", false)]
        [InlineData("^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$", "ababbb", true)]
        [InlineData("^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$", "bababa", false)]
        [InlineData("^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$", "abbbab", true)]
        [InlineData("^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$", "aaabbb", false)]
        [InlineData("^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$", "aaabbbb", false)]
        public static void MasterRule_CorrectlyValidates_Messages(string rule, string message, bool expectedValidity)
        {
            //Arrange

            //Act
            var actualValidity = Regex.IsMatch(message, rule);

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }


    }
}
