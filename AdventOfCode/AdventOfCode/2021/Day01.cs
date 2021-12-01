using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day01
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2021\Inputs\Day01.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            int lastDepth = int.Parse(input[0]);
            int depthIncreases = 0;

            for (int i = 1; i < input.Length; i++)
            {
                int currentDepth = int.Parse(input[i]);

                if (currentDepth > lastDepth)
                {
                    depthIncreases++;
                }

                lastDepth = currentDepth;
            }

            return depthIncreases;
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            int depthIncreases = 0;
            int lastWindow = int.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                int currentWindow = input.Skip(i).Take(3).Sum(d => int.Parse(d));

                if (currentWindow > lastWindow)
                {
                    depthIncreases++;
                }

                lastWindow = currentWindow;
            }

            return depthIncreases;
        }
    }
}
