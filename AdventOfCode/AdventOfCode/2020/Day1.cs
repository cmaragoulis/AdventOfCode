using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day1
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day1.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            var numbers = input.Select(s => int.Parse(s)).ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        return numbers[i] * numbers[j];
                    }
                }
            }

            return -1;
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);
            var numbers = input.Select(s => int.Parse(s)).ToList();

            for (int i = 0; i < numbers.Count - 2; i++)
            {
                for (int j = i + 1; j < numbers.Count - 1; j++)
                {
                    for (int k = j + 1; k < numbers.Count; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            return numbers[i] * numbers[j] * numbers[k];
                        }
                    }
                }
            }

            return -1;
        }
    }
}
