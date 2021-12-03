using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day03
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2021\Inputs\Day03.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);
            string gammaRate = string.Empty;

            for (int i = 0; i < input[0].Length; i++)
            {
                gammaRate += GetMostCommonBit(input, i);
            }

            string epsilonRate = GetEpsilonRate(gammaRate);

            int gamma = Convert.ToInt32(gammaRate, 2);
            int epsilon = Convert.ToInt32(epsilonRate, 2);

            return gamma * epsilon;
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            var oxygen = GetRatingReading(input, BitCriteria.Oxygen);
            var co2 = GetRatingReading(input, BitCriteria.CO2);

            var oxygenDecimal = Convert.ToInt32(oxygen, 2);
            var co2Decimal = Convert.ToInt32(co2, 2);

            return oxygenDecimal * co2Decimal;
        }

        public static string GetEpsilonRate(string gamaRate)
        {
            return string.Join(string.Empty, gamaRate.Select(c => c == '0' ? '1' : '0'));
        }

        public static int GetMostCommonBit(IEnumerable<string> input, int position)
        {
            int readings = input.Count() / 2;
            int zeroes = input.Count(d => d[position] == '0');

            if (zeroes > readings)
            {
                return 0;
            }
            else if (zeroes == readings)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        static string GetRatingReading(IEnumerable<string> input, BitCriteria bitCriteria)
        {
            var readings = input;

            for (int i = 0; i < input.First().Length; i++)
            {
                int mostCommonBit = GetMostCommonBit(readings, i);

                string bitFilter = string.Empty;
                switch (bitCriteria)
                {
                    case BitCriteria.Oxygen:
                        bitFilter = mostCommonBit != -1 ? $"{mostCommonBit}" : "1";
                        break;
                    case BitCriteria.CO2:
                        string leastCommonBit = mostCommonBit == 1 ? "0" : "1";
                        bitFilter = mostCommonBit != -1 ? leastCommonBit : "0";
                        break;
                }

                readings = readings.Where(d => d[i].ToString() == bitFilter).ToList();

                if (readings.Count() == 1)
                {
                    break;
                }
            }

            return readings.First();
        }

        enum BitCriteria
        {
            Oxygen,
            CO2
        }
    }
}
