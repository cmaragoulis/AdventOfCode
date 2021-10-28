using AdventOfCode2020;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day24Tests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public static void Test(int days, int expectedBlackTiles)
        {
            //Arrange
            var input = new string[]
            {
                "sesenwnenenewseeswwswswwnenewsewsw",
                "neeenesenwnwwswnenewnwwsewnenwseswesw",
                "seswneswswsenwwnwse",
                "nwnwneseeswswnenewneswwnewseswneseene",
                "swweswneswnenwsewnwneneseenw",
                "eesenwseswswnenwswnwnwsewwnwsene",
                "sewnenenenesenwsewnenwwwse",
                "wenwwweseeeweswwwnwwe",
                "wsweesenenewnwwnwsenewsenwwsesesenwne",
                "neeswseenwwswnwswswnw",
                "nenwswwsewswnenenewsenwsenwnesesenew",
                "enewnwewneswsewnwswenweswnenwsenwsw",
                "sweneswneswneneenwnewenewwneswswnese",
                "swwesenesewenwneswnwwneseswwne",
                "enesenwswwswneneswsenwnewswseenwsese",
                "wnwnesenesenenwwnenwsewesewsesesew",
                "nenewswnwewswnenesenwnesewesw",
                "eneswnwswnwsenenwnwnwwseeswneewsenese",
                "neswnwewnwnwseenwseesewsenwsweewe",
                "wseweeenwnesenwwwswnew"
            };
            var startingFloor = Day24.InitializeFloor(input);

            //Act
            var finalFloor = Day24.GetFinalState(startingFloor, days);
            var actualBlackTiles = finalFloor.Count(t => t.Value == true);

            //Assert
            Assert.Equal(expectedBlackTiles, actualBlackTiles);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 1, 15 };
            yield return new object[] { 2, 12 };
            yield return new object[] { 3, 25 };
            yield return new object[] { 4, 14 };
            yield return new object[] { 5, 23 };
            yield return new object[] { 6, 28 };
            yield return new object[] { 7, 41 };
            yield return new object[] { 8, 37 };
            yield return new object[] { 9, 49 };
            yield return new object[] { 10, 37 };
            yield return new object[] { 20, 132 };
            yield return new object[] { 30, 259 };
            yield return new object[] { 40, 406 };
            yield return new object[] { 50, 566 };
            yield return new object[] { 60, 788 };
            yield return new object[] { 70, 1106 };
            yield return new object[] { 80, 1373 };
            yield return new object[] { 90, 1844 };
            yield return new object[] { 100, 2208 };
        }
    }
}
