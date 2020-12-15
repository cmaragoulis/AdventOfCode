using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public enum Section
    {
        Row, Column
    }

    public class Day05
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day05.txt";

        public static int Problem1()
        {
            var boardingPasses = File.ReadAllLines(inputPath);
            int maxSeatId = int.MinValue;

            foreach (var boardingPass in boardingPasses)
            {
                int seatId = DecodeBoardingPass(boardingPass);

                if (seatId > maxSeatId)
                {
                    maxSeatId = seatId;
                }
            }

            return maxSeatId;
        }

        public static int Problem2()
        {
            var boardingPasses = File.ReadAllLines(inputPath);

            var seatIds = boardingPasses
                .Select(boardingPass => DecodeBoardingPass(boardingPass))
                .OrderBy(seatId => seatId)
                .ToList();

            for (int i = 0; i < seatIds.Count - 1; i++)
            {
                if (seatIds[i + 1] != seatIds[i] + 1)
                {
                    return seatIds[i] + 1;
                }
            }

            return -1;
        }

        public static int DecodeBoardingPass(string boardingPass)
        {
            int row = DecodeSection(boardingPass, Section.Row);
            int column = DecodeSection(boardingPass, Section.Column);
            return (row * 8) + column;
        }

        private static int DecodeSection(string boardingPass, Section section)
        {
            int minValue = 0, maxValue;
            char lowLetter, highLetter;
            string boardigPassSection;

            switch (section)
            {
                case Section.Row:
                    maxValue = 127;
                    boardigPassSection = boardingPass[..7];
                    lowLetter = 'F';
                    highLetter = 'B';
                    break;
                case Section.Column:
                    maxValue = 7;
                    boardigPassSection = boardingPass[^3..];
                    lowLetter = 'L';
                    highLetter = 'R';
                    break;
                default:
                    throw new ArgumentException("Invalid section");
            }

            foreach (var letter in boardigPassSection)
            {
                if (letter == lowLetter)
                {
                    maxValue -= (int)Math.Round((maxValue - minValue) / 2.0);
                }
                else if (letter == highLetter)
                {
                    minValue += (int)Math.Round((maxValue - minValue) / 2.0);
                }
                else
                {
                    throw new ArgumentException("Invalid boarding pass");
                }
            }

            return boardigPassSection[^1] == lowLetter ? minValue : maxValue;
        }
    }
}
