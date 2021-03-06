﻿using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class Day03
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day03.txt";

        public static int Problem1()
        {
            var map = File.ReadAllLines(inputPath);

            int stepsRight = 3;
            int stepsDown = 1;

            int trees = TraverseMap(map, stepsRight, stepsDown);

            return trees;
        }

        public static int Problem2()
        {
            var map = File.ReadAllLines(inputPath);
            var answer = 1;

            var slopes = new List<(int StepsRight, int StepsDown)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            foreach (var slope in slopes)
            {
                answer *= TraverseMap(map, slope.StepsRight, slope.StepsDown);
            }

            return answer;
        }

        private static int TraverseMap(string[] map, int stepsRight, int stepsDown)
        {
            int width = map[0].Length;
            int height = map.Length;

            int trees = 0;
            int x = 0;
            int y = 0;

            while (y < height - stepsDown)
            {
                x = (x + stepsRight) % width;
                y += stepsDown;

                if (map[y][x] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }
    }
}
