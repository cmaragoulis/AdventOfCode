using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day10
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day10.txt";

        public static long Problem1()
        {
            var adapters = File.ReadAllLines(inputPath)
                .Select(l => int.Parse(l)).ToList();

            return FindDistributionOfAdapters(adapters);
        }

        public static long Problem2()
        {
            var adapters = File.ReadAllLines(inputPath)
                .Select(l => int.Parse(l)).ToList();


            return -1;
        }

        public static int FindDistributionOfAdapters(List<int> adapters)
        {
            //add charge outlet and device built in adapter
            adapters.Add(0);
            adapters.Sort();
            adapters.Add(adapters.Last() + 3);

            int differenceOfOne = 0;
            int differenceOfTwo = 0;
            int differenceOfThree = 0;

            for (int i = 0; i < adapters.Count - 1; i++)
            {
                switch (adapters[i + 1] - adapters[i])
                {
                    case 1:
                        differenceOfOne++;
                        break;
                    case 2:
                        differenceOfTwo++;
                        break;
                    case 3:
                        differenceOfThree++;
                        break;
                }
            }

            return differenceOfOne * differenceOfThree;
        }

        public static int CalculatePermutations(List<int> adapters)
        {
            //add charge outlet and device built in adapter
            adapters.Add(0);
            adapters.Sort();
            adapters.Add(adapters.Last() + 3);

            var differenceSequence = new List<int>();

            for (int i = 0; i < adapters.Count - 1; i++)
            {
                differenceSequence.Add(adapters[i + 1] - adapters[i]);
            }

            return -1;
        }
    }
}
