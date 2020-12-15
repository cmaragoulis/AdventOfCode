using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day07
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day07.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath).ToList();

            var rules = ExtractRulesFromInput(input);
            string targetBag = "shiny gold";

            int answer = 0;

            foreach (var bag in rules.Keys)
            {
                if (BagContains(bag, targetBag, rules))
                {
                    answer++;
                }
            }

            return answer;
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath).ToList();
            var rules = ExtractRulesFromInput(input);
            string targetBag = "shiny gold";

            var answer = CountContainedBags(targetBag, rules);

            return answer;
        }

        public static bool BagContains(string bag, string targetBag, Dictionary<string, List<(int n, string bagColor)>> rules)
        {
            foreach (var (_, bagColor) in rules[bag])
            {
                if (bagColor == targetBag || BagContains(bagColor, targetBag, rules))
                {
                    return true;
                }
            }

            return false;
        }

        public static int CountContainedBags(string targetBag, Dictionary<string, List<(int n, string bagColor)>> rules)
        {
            var answer = 0;

            foreach (var (n, bagColor) in rules[targetBag])
            {
                answer += n + n * CountContainedBags(bagColor, rules);
            }

            return answer;
        }

        public static Dictionary<string, List<(int n, string bagColor)>> ExtractRulesFromInput(List<string> input)
        {
            var rules = new Dictionary<string, List<(int n, string bagColor)>>();

            foreach (var line in input)
            {
                var key = Regex.Match(line, @"^\w+ \w+").Value;
                var value = Regex.Matches(line, @"(?<n>\d+) (?<bagColor>\w+ \w+)")
                    .Select(m => (int.Parse(m.Groups["n"].Value), m.Groups["bagColor"].Value))
                    .ToList();

                rules[key] = value;
            }

            return rules;
        }
    }
}
