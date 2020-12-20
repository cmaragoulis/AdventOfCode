using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day19
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day19.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            ReadInput(input, out Dictionary<int, string> rules, out List<string> messages);

            var masterRule = BuildMasterRule(rules);

            var masterRuleMatch = new Regex(@masterRule);

            int validMessages = 0;
            foreach (var message in messages)
            {
                if (masterRuleMatch.IsMatch(message))
                {
                    validMessages++;
                }
            }

            return validMessages;
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            return -1;
        }

        private static void ReadInput(string[] input, out Dictionary<int, string> rules, out List<string> messages)
        {
            rules = new Dictionary<int, string>();
            messages = new List<string>();

            var ruleMatch = new Regex(@"(\d+): (.+)");

            foreach (var line in input)
            {
                if (Regex.IsMatch(line, @"^\d"))
                {
                    var match = ruleMatch.Match(line);

                    var ruleIndex = int.Parse(match.Groups[1].Value);
                    rules[ruleIndex] = match.Groups[2].Value.Replace("\"", string.Empty);
                }
                else if (Regex.IsMatch(line, @"^[ab]"))
                {
                    messages.Add(line);
                }
            }
        }

        public static string BuildMasterRule(Dictionary<int, string> rules)
        {
            var digitMatch = new Regex(@"\d+");

            var replacedRules = new List<int>();

            //while rule 0 has digits
            while (digitMatch.IsMatch(rules[0]))
            {
                //find the first rule that has no digits and has not been already replaced
                var completedRule = rules.First(r => !digitMatch.IsMatch(r.Value) && !replacedRules.Contains(r.Key));

                var ruleIndex = completedRule.Key;
                var ruleText = completedRule.Value;

                if (ruleText != "a" & ruleText != "b")
                {
                    ruleText = $"({ruleText})";
                    rules[completedRule.Key] = ruleText;
                }

                foreach (var rule in rules)
                {
                    rules[rule.Key] = ReplaceCompletedRule(rule.Value, ruleIndex, ruleText);
                }

                replacedRules.Add(ruleIndex);
            }

            //add anchor characters and replace all spaces
            var masterRule = $"^{rules[0].Replace(" ", string.Empty)}$";

            return masterRule;
        }

        public static string ReplaceCompletedRule(string rule, int completedRuleIndex, string completedRuleText)
        {
            //pad rule with spaces to make replacements easier
            rule = $" {rule} ";
            string ruleMatch = $" {completedRuleIndex} ";

            while (Regex.IsMatch(rule, ruleMatch))
            {
                rule = Regex.Replace(rule, ruleMatch, $" {completedRuleText} ");
            }

            return rule.Trim();
        }
    }
}
