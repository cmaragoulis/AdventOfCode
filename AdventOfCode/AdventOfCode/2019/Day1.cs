using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day1
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2019\Inputs\Day1.txt";

        public static int Problem1()
        {
            var modules = File.ReadAllLines(inputPath).Select(m => int.Parse(m));
            int totalFuel = 0;

            foreach (var module in modules)
            {
                totalFuel += (int)Math.Floor(module / 3.0) - 2;
            }


            return totalFuel;
        }

        public static int Problem2()
        {
            var modules = File.ReadAllLines(inputPath).Select(m => int.Parse(m));
            int totalFuel = 0;

            foreach (var module in modules)
            {
                int moduleFuel = 0;

                int currentMass = module;
                while (true)
                {
                    var currentFuel = (int)Math.Floor(currentMass / 3.0) - 2;

                    if (currentFuel < 0)
                    {
                        break;
                    }
                    else
                    {
                        moduleFuel += currentFuel;
                        currentMass = currentFuel;
                    }
                }

                totalFuel += moduleFuel;
            }

            return totalFuel;
        }
    }
}
