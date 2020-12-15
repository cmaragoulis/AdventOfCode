using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day06
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day06.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            int problemAnswer = 0;
            var groupAnwers = new HashSet<char>();

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    problemAnswer += groupAnwers.Count;
                    groupAnwers.Clear();
                    continue;
                }

                foreach (var letter in line)
                {
                    groupAnwers.Add(letter);
                }
            }

            //add last groups answers
            problemAnswer += groupAnwers.Count;

            return problemAnswer;
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            int problemAnswer = 0;
            var groupAnwers = new Dictionary<char, int>();
            int peopleInGroup = 0;

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    problemAnswer += groupAnwers.Count(answer => answer.Value == peopleInGroup);
                    peopleInGroup = 0;
                    groupAnwers.Clear();
                    continue;
                }

                peopleInGroup++;

                foreach (var letter in line)
                {
                    if (groupAnwers.ContainsKey(letter))
                    {
                        groupAnwers[letter]++;
                    }
                    else
                    {
                        groupAnwers[letter] = 1;
                    }
                }
            }

            //add last groups answers
            problemAnswer += groupAnwers.Count(answer => answer.Value == peopleInGroup);

            return problemAnswer;
        }
    }
}
