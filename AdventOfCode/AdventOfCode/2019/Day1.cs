using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    class Day1
    {
        private static readonly string baseInputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2019\Inputs";

        public static int Problem1()
        {
            var modules = File.ReadAllLines($@"{baseInputPath}\Day1.txt").Select(m => int.Parse(m));
            int totalFuel = 0;

            foreach (var module in modules)
            {
                totalFuel += (int)Math.Floor(module / 3.0) - 2;
            }


            return totalFuel;
        }

        public static int Problem2()
        {
            var modules = File.ReadAllLines($@"{baseInputPath}\Day1.txt").Select(m => int.Parse(m));
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
