using AdventOfCode2020;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day11Tests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public static void CalculateNextState_Returns_CorrectResult(
            List<string> initialState, int occupiedLimit, OccupiedRule rule, List<string> expectedNextState)
        {
            //Arrange

            //Act
            var actualNextState = Day11.CalculateNextState(initialState, occupiedLimit, rule);

            //Assert
            Assert.Equal(expectedNextState, actualNextState);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                new List<string>
                {
                    "L.LL.LL.LL",
                    "LLLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLLL",
                    "L.LLLLLL.L",
                    "L.LLLLL.LL"
                },
                4,
                OccupiedRule.Adjacent,
                new List<string>
                {
                    "#.##.##.##",
                    "#######.##",
                    "#.#.#..#..",
                    "####.##.##",
                    "#.##.##.##",
                    "#.#####.##",
                    "..#.#.....",
                    "##########",
                    "#.######.#",
                    "#.#####.##"
                }
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.##.##.##",
                    "#######.##",
                    "#.#.#..#..",
                    "####.##.##",
                    "#.##.##.##",
                    "#.#####.##",
                    "..#.#.....",
                    "##########",
                    "#.######.#",
                    "#.#####.##"
                },
                4,
                OccupiedRule.Adjacent,
                new List<string>
                {
                    "#.LL.L#.##",
                    "#LLLLLL.L#",
                    "L.L.L..L..",
                    "#LLL.LL.L#",
                    "#.LL.LL.LL",
                    "#.LLLL#.##",
                    "..L.L.....",
                    "#LLLLLLLL#",
                    "#.LLLLLL.L",
                    "#.#LLLL.##"
                }
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.LL.L#.##",
                    "#LLLLLL.L#",
                    "L.L.L..L..",
                    "#LLL.LL.L#",
                    "#.LL.LL.LL",
                    "#.LLLL#.##",
                    "..L.L.....",
                    "#LLLLLLLL#",
                    "#.LLLLLL.L",
                    "#.#LLLL.##"
                },
                4,
                OccupiedRule.Adjacent,
                new List<string>
                {
                    "#.##.L#.##",
                    "#L###LL.L#",
                    "L.#.#..#..",
                    "#L##.##.L#",
                    "#.##.LL.LL",
                    "#.###L#.##",
                    "..#.#.....",
                    "#L######L#",
                    "#.LL###L.L",
                    "#.#L###.##"
                },
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.##.L#.##",
                    "#L###LL.L#",
                    "L.#.#..#..",
                    "#L##.##.L#",
                    "#.##.LL.LL",
                    "#.###L#.##",
                    "..#.#.....",
                    "#L######L#",
                    "#.LL###L.L",
                    "#.#L###.##"
                },
                4,
                OccupiedRule.Adjacent,
                new List<string>
                {
                    "#.#L.L#.##",
                    "#LLL#LL.L#",
                    "L.L.L..#..",
                    "#LLL.##.L#",
                    "#.LL.LL.LL",
                    "#.LL#L#.##",
                    "..L.L.....",
                    "#L#LLLL#L#",
                    "#.LLLLLL.L",
                    "#.#L#L#.##"
                }
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.#L.L#.##",
                    "#LLL#LL.L#",
                    "L.L.L..#..",
                    "#LLL.##.L#",
                    "#.LL.LL.LL",
                    "#.LL#L#.##",
                    "..L.L.....",
                    "#L#LLLL#L#",
                    "#.LLLLLL.L",
                    "#.#L#L#.##"
                },
                4,
                OccupiedRule.Adjacent,
                new List<string>
                {
                    "#.#L.L#.##",
                    "#LLL#LL.L#",
                    "L.#.L..#..",
                    "#L##.##.L#",
                    "#.#L.LL.LL",
                    "#.#L#L#.##",
                    "..L.L.....",
                    "#L#L##L#L#",
                    "#.LLLLLL.L",
                    "#.#L#L#.##"
                }
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.#L.L#.##",
                    "#LLL#LL.L#",
                    "L.#.L..#..",
                    "#L##.##.L#",
                    "#.#L.LL.LL",
                    "#.#L#L#.##",
                    "..L.L.....",
                    "#L#L##L#L#",
                    "#.LLLLLL.L",
                    "#.#L#L#.##"
                },
                4,
                OccupiedRule.Adjacent,
                new List<string>
                {
                    "#.#L.L#.##",
                    "#LLL#LL.L#",
                    "L.#.L..#..",
                    "#L##.##.L#",
                    "#.#L.LL.LL",
                    "#.#L#L#.##",
                    "..L.L.....",
                    "#L#L##L#L#",
                    "#.LLLLLL.L",
                    "#.#L#L#.##"
                }
            };

            //line of sight
            yield return new object[]
{
                new List<string>
                {
                    "L.LL.LL.LL",
                    "LLLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLLL",
                    "L.LLLLLL.L",
                    "L.LLLLL.LL"
                },
                5,
                OccupiedRule.LineOfSight,
                new List<string>
                {
                    "#.##.##.##",
                    "#######.##",
                    "#.#.#..#..",
                    "####.##.##",
                    "#.##.##.##",
                    "#.#####.##",
                    "..#.#.....",
                    "##########",
                    "#.######.#",
                    "#.#####.##"
                }
};

            yield return new object[]
            {
                new List<string>
                {
                    "#.##.##.##",
                    "#######.##",
                    "#.#.#..#..",
                    "####.##.##",
                    "#.##.##.##",
                    "#.#####.##",
                    "..#.#.....",
                    "##########",
                    "#.######.#",
                    "#.#####.##"
                },
                5,
                OccupiedRule.LineOfSight,
                new List<string>
                {
                    "#.LL.LL.L#",
                    "#LLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLL#",
                    "#.LLLLLL.L",
                    "#.LLLLL.L#"
                }
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.LL.LL.L#",
                    "#LLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLL#",
                    "#.LLLLLL.L",
                    "#.LLLLL.L#"
                },
                5,
                OccupiedRule.LineOfSight,
                new List<string>
                {
                    "#.L#.##.L#",
                    "#L#####.LL",
                    "L.#.#..#..",
                    "##L#.##.##",
                    "#.##.#L.##",
                    "#.#####.#L",
                    "..#.#.....",
                    "LLL####LL#",
                    "#.L#####.L",
                    "#.L####.L#"
                },
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.L#.##.L#",
                    "#L#####.LL",
                    "L.#.#..#..",
                    "##L#.##.##",
                    "#.##.#L.##",
                    "#.#####.#L",
                    "..#.#.....",
                    "LLL####LL#",
                    "#.L#####.L",
                    "#.L####.L#"
                },
                5,
                OccupiedRule.LineOfSight,
                new List<string>
                {
                    "#.L#.L#.L#",
                    "#LLLLLL.LL",
                    "L.L.L..#..",
                    "##LL.LL.L#",
                    "L.LL.LL.L#",
                    "#.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLL#",
                    "#.LLLLL#.L",
                    "#.L#LL#.L#"
                }
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.L#.L#.L#",
                    "#LLLLLL.LL",
                    "L.L.L..#..",
                    "##LL.LL.L#",
                    "L.LL.LL.L#",
                    "#.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLL#",
                    "#.LLLLL#.L",
                    "#.L#LL#.L#"
                },
                5,
                OccupiedRule.LineOfSight,
                new List<string>
                {
                    "#.L#.L#.L#",
                    "#LLLLLL.LL",
                    "L.L.L..#..",
                    "##L#.#L.L#",
                    "L.L#.#L.L#",
                    "#.L####.LL",
                    "..#.#.....",
                    "LLL###LLL#",
                    "#.LLLLL#.L",
                    "#.L#LL#.L#"
                }
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.L#.L#.L#",
                    "#LLLLLL.LL",
                    "L.L.L..#..",
                    "##L#.#L.L#",
                    "L.L#.#L.L#",
                    "#.L####.LL",
                    "..#.#.....",
                    "LLL###LLL#",
                    "#.LLLLL#.L",
                    "#.L#LL#.L#"
                },
                5,
                OccupiedRule.LineOfSight,
                new List<string>
                {
                    "#.L#.L#.L#",
                    "#LLLLLL.LL",
                    "L.L.L..#..",
                    "##L#.#L.L#",
                    "L.L#.LL.L#",
                    "#.LLLL#.LL",
                    "..#.L.....",
                    "LLL###LLL#",
                    "#.LLLLL#.L",
                    "#.L#LL#.L#"
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetTestData2))]
        public static void CountOccupiedSeats_Returns_CorrectResult(List<string> state, int expectedAnswer)
        {
            //Arrange

            //Act
            var actualAnswer = Day11.CountOccupiedSeats(state);

            //Assert
            Assert.Equal(expectedAnswer, actualAnswer);
        }

        public static IEnumerable<object[]> GetTestData2()
        {
            yield return new object[]
            {
                new List<string>
                {
                    "L.LL.LL.LL",
                    "LLLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLLL",
                    "L.LLLLLL.L",
                    "L.LLLLL.LL"
                },
                0
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.##.##.##",
                    "#######.##",
                    "#.#.#..#..",
                    "####.##.##",
                    "#.##.##.##",
                    "#.#####.##",
                    "..#.#.....",
                    "##########",
                    "#.######.#",
                    "#.#####.##"
                },
                71
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.LL.L#.##",
                    "#LLLLLL.L#",
                    "L.L.L..L..",
                    "#LLL.LL.L#",
                    "#.LL.LL.LL",
                    "#.LLLL#.##",
                    "..L.L.....",
                    "#LLLLLLLL#",
                    "#.LLLLLL.L",
                    "#.#LLLL.##"
                },
                20
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.##.L#.##",
                    "#L###LL.L#",
                    "L.#.#..#..",
                    "#L##.##.L#",
                    "#.##.LL.LL",
                    "#.###L#.##",
                    "..#.#.....",
                    "#L######L#",
                    "#.LL###L.L",
                    "#.#L###.##"
                },
                51
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.#L.L#.##",
                    "#LLL#LL.L#",
                    "L.L.L..#..",
                    "#LLL.##.L#",
                    "#.LL.LL.LL",
                    "#.LL#L#.##",
                    "..L.L.....",
                    "#L#LLLL#L#",
                    "#.LLLLLL.L",
                    "#.#L#L#.##"
                },
                30
            };

            yield return new object[]
            {
                new List<string>
                {
                    "#.#L.L#.##",
                    "#LLL#LL.L#",
                    "L.#.L..#..",
                    "#L##.##.L#",
                    "#.#L.LL.LL",
                    "#.#L#L#.##",
                    "..L.L.....",
                    "#L#L##L#L#",
                    "#.LLLLLL.L",
                    "#.#L#L#.##"
                },
                37
            };
        }

        [Theory]
        [MemberData(nameof(GetTestData3))]
        public static void CountLineOfSightOccupiedSeats_Returns_CorrectResult(
            List<string> state, int rowNumber, int seatNumber, int expectedAnswer)
        {
            //Arrange

            //Act
            var actualAnswer = Day11.CountLineOfSightOccupiedSeats(state, rowNumber, seatNumber);

            //Assert
            Assert.Equal(expectedAnswer, actualAnswer);
        }

        public static IEnumerable<object[]> GetTestData3()
        {
            yield return new object[]
            {
                new List<string>
                {
                    ".......#.",
                    "...#.....",
                    ".#.......",
                    ".........",
                    "..#L....#",
                    "....#....",
                    ".........",
                    "#........",
                    "...#....."
                },
                4,
                3,
                8
            };

            yield return new object[]
            {
                new List<string>
                {
                    ".##.##.",
                    "#.#.#.#",
                    "##...##",
                    "...L...",
                    "##...##",
                    "#.#.#.#",
                    ".##.##."
                },
                3,
                3,
                0
};
        }

    }
}
