using System;
using System.IO;

namespace AdventOfCode2021
{
    public class Day02
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2021\Inputs\Day02.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            int horizontal = 0;
            int depth = 0;

            foreach (var line in input)
            {
                var parts = line.Split(' ');

                string instruction = parts[0];
                int units = int.Parse(parts[1]);

                switch (instruction)
                {
                    case "forward":
                        horizontal += units;
                        break;
                    case "up":
                        depth -= units;
                        break;
                    case "down":
                        depth += units;
                        break;
                }
            }

            Console.WriteLine($"Horizontal position: {horizontal}, Depth: {depth}");

            return horizontal * depth;
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (var line in input)
            {
                var parts = line.Split(' ');

                string instruction = parts[0];
                int units = int.Parse(parts[1]);

                switch (instruction)
                {
                    case "forward":
                        horizontal += units;
                        depth += aim * units;
                        break;
                    case "up":
                        aim -= units;
                        break;
                    case "down":
                        aim += units;
                        break;
                }
            }

            Console.WriteLine($"Horizontal position: {horizontal}, Depth: {depth}");

            return horizontal * depth;
        }
    }
}
