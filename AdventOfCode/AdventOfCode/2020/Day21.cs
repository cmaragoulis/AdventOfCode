using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day21
    {
        const string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day21.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);
            var foods = new List<(string[], string[])>();
            var allergensPerIngredient = new Dictionary<string, List<string>>();

            (var ingredients, var allergens) = ExtractIngredientsAndAllergens(input, ref foods);

            foreach (var ingredient in ingredients)
            {
                allergensPerIngredient[ingredient] = allergens.ToList();

                foreach (var allergen in allergens)
                {
                    if (input.Any(line => line.Contains($" {allergen}") && !line.Contains($" {ingredient} ")))
                    {
                        allergensPerIngredient[ingredient].Remove(allergen);
                    }
                }
            }

            var allergenFreeIngredients = allergensPerIngredient
                .Where(entry => entry.Value.Count == 0)
                .Select(pair => pair.Key);

            var answer = 0;

            foreach (var ingredient in allergenFreeIngredients)
            {
                var timesIngredientAppears = foods.Count(food => food.Item1.Contains(ingredient));

                answer += timesIngredientAppears;
            }

            return answer;
        }

        public static (HashSet<string>, HashSet<string>) ExtractIngredientsAndAllergens(string[] input, ref List<(string[], string[])> foods)
        {
            var uniqueIngredients = new HashSet<string>();
            var uniqueAllergens = new HashSet<string>();

            foreach (var line in input)
            {
                var parts = line.Split(" (contains ");

                var ingredients = parts[0].Split(" ");
                var allergens = parts[1].TrimEnd(')').Split(", ");

                foreach (var ingredient in ingredients)
                {
                    uniqueIngredients.Add(ingredient);
                }

                foreach (var allergen in allergens)
                {
                    uniqueAllergens.Add(allergen);
                }

                foods.Add((ingredients, allergens));
            }

            return (uniqueIngredients, uniqueAllergens);
        }
    }
}
