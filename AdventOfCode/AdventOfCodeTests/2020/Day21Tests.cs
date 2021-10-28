using AdventOfCode2020;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day21Tests
    {
        [Fact]
        public static void Test()
        {
            // Arrange
            var input = new string[] {
                "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)",
                "trh fvjkl sbzzf mxmxvkd (contains dairy)",
                "sqjhc fvjkl (contains soy)",
                "sqjhc mxmxvkd sbzzf (contains fish)"
            };
            var foods = new List<(string[], string[])>();

            var expectedIngredients = new List<string>()
            {
                "mxmxvkd", "kfcds", "sqjhc", "nhms", "trh", "fvjkl", "sbzzf"
            };

            var expectedAllergens = new List<string>()
            {
                "dairy", "fish", "soy"
            };

            // Act
            (var actualIngredients, var actualAllergens) = Day21.ExtractIngredientsAndAllergens(input, ref foods);

            // Assert
            actualIngredients.Should().BeEquivalentTo(expectedIngredients);
            actualAllergens.Should().BeEquivalentTo(expectedAllergens);
        }
    }
}
