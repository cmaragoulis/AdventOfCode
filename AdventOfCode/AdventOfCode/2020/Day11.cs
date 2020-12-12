using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day11
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day11.txt";

        public static int Problem1()
        {
            var initialState = File.ReadAllLines(inputPath).ToList();

            var finalState = CalculateFinalState(initialState);

            var answer = CountOccupiedSeats(finalState);

            return answer;
        }
        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath).ToList();



            return -1;
        }

        public static int CountOccupiedSeats(List<string> state)
        {
            int occupiedSeats = 0;
            foreach (var row in state)
            {
                foreach (var seat in row)
                {
                    occupiedSeats += seat == '#' ? 1 : 0;
                }
            }
            return occupiedSeats;
        }

        public static List<string> CalculateFinalState(List<string> initialState)
        {
            List<string> currentState;
            List<string> nextState = new List<string>(initialState);

            do
            {
                currentState = new List<string>(nextState);
                nextState = CalculateNextState(currentState);
            }
            while (!nextState.SequenceEqual(currentState));

            return nextState;
        }

        public static List<string> CalculateNextState(List<string> currentState)
        {
            var nextState = new List<string>();

            for (int rowNumber = 0; rowNumber < currentState.Count; rowNumber++)
            {
                var row = currentState[rowNumber];
                string nextRow = string.Empty;

                for (int seatNumber = 0; seatNumber < row.Length; seatNumber++)
                {
                    nextRow += CalculateNextSeatState(currentState, rowNumber, seatNumber);
                }

                nextState.Add(nextRow);
            }

            return nextState;
        }

        private static char CalculateNextSeatState(List<string> currentState, int rowNumber, int seatNumber)
        {
            var currentSeat = currentState[rowNumber][seatNumber];

            switch (currentSeat)
            {
                case '.':
                    return '.';
                case 'L':
                    return CountAdjacentOccupiedSeats(currentState, rowNumber, seatNumber) == 0
                        ? '#'
                        : 'L';
                case '#':
                    return CountAdjacentOccupiedSeats(currentState, rowNumber, seatNumber) >= 4
                        ? 'L'
                        : '#';
                default:
                    throw new Exception("Invalid seat state");
            }
        }

        private static int CountAdjacentOccupiedSeats(List<string> currentState, int rowNumber, int seatNumber)
        {
            int occupiedSeats = 0;

            if (rowNumber - 1 >= 0)
            {
                var previousRow = currentState[rowNumber - 1];

                for (int i = seatNumber - 1; i <= seatNumber + 1; i++)
                {
                    if (i < 0 || i >= previousRow.Length)
                    {
                        continue;
                    }
                    else
                    {
                        occupiedSeats += (previousRow[i] == '#') ? 1 : 0;
                    }
                }
            }

            if (rowNumber + 1 < currentState.Count)
            {
                var nextRow = currentState[rowNumber + 1];

                for (int i = seatNumber - 1; i <= seatNumber + 1; i++)
                {
                    if (i < 0 || i >= nextRow.Length)
                    {
                        continue;
                    }
                    else
                    {
                        occupiedSeats += (nextRow[i] == '#') ? 1 : 0;
                    }
                }
            }

            if (seatNumber - 1 >= 0)
            {
                occupiedSeats += (currentState[rowNumber][seatNumber - 1] == '#') ? 1 : 0;
            }

            if (seatNumber + 1 < currentState[rowNumber].Length)
            {
                occupiedSeats += (currentState[rowNumber][seatNumber + 1] == '#') ? 1 : 0;
            }

            return occupiedSeats;
        }
    }
}
