using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day2
    {
        private static readonly string baseInputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs";

        public static int Problem1()
        {
            int validPasswords = 0;
            var input = File.ReadAllLines($@"{baseInputPath}\Day2.txt");

            foreach (var line in input)
            {
                var match = Regex.Match(line, "(?<min>[0-9]+)-(?<max>[0-9]+) (?<letter>.): (?<password>.+)");
                var min = int.Parse(match.Groups["min"].Value);
                var max = int.Parse(match.Groups["max"].Value);
                var letter = match.Groups["letter"].Value;
                var password = match.Groups["password"].Value;

                var occurences = Regex.Matches(password, letter).Count;

                if (occurences >= min && occurences <= max)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        public static int Problem2()
        {
            int validPasswords = 0;
            var input = File.ReadAllLines($@"{baseInputPath}\Day2.txt");

            foreach (var line in input)
            {
                var match = Regex.Match(line, "(?<position1>[0-9]+)-(?<position2>[0-9]+) (?<letter>.): (?<password>.+)");

                //subtract 1 to convert to zero based index
                var position1 = int.Parse(match.Groups["position1"].Value) - 1;
                var position2 = int.Parse(match.Groups["position2"].Value) - 1;
                var letter = match.Groups["letter"].Value;
                var password = match.Groups["password"].Value;

                if (
                    (letter == password[position1].ToString() || letter == password[position2].ToString())
                    && (password[position1] != password[position2])
                    )
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }
    }
}
