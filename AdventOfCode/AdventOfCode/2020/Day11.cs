using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public enum OccupiedRule
    {
        Adjacent, LineOfSight
    }

    public class Day11
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day11.txt";

        public static int Problem1()
        {
            var initialState = File.ReadAllLines(inputPath).ToList();

            var finalState = CalculateFinalState(initialState, 4, OccupiedRule.Adjacent);

            var answer = CountOccupiedSeats(finalState);

            return answer;
        }
        public static int Problem2()
        {
            var initialState = File.ReadAllLines(inputPath).ToList();

            var finalState = CalculateFinalState(initialState, 5, OccupiedRule.LineOfSight);

            var answer = CountOccupiedSeats(finalState);

            return answer;
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

        public static List<string> CalculateFinalState(List<string> initialState, int occupiedLimit, OccupiedRule rule)
        {
            List<string> currentState;
            List<string> nextState = new List<string>(initialState);

            long turnCounter = 0;

            do
            {
                currentState = new List<string>(nextState);
                nextState = CalculateNextState(currentState, occupiedLimit, rule);
                turnCounter++;
            }
            while (!nextState.SequenceEqual(currentState));

            return nextState;
        }

        public static List<string> CalculateNextState(List<string> currentState, int occupiedLimit, OccupiedRule rule)
        {
            var nextState = new List<string>();

            for (int rowNumber = 0; rowNumber < currentState.Count; rowNumber++)
            {
                var row = currentState[rowNumber];
                string nextRow = string.Empty;

                for (int seatNumber = 0; seatNumber < row.Length; seatNumber++)
                {
                    nextRow += CalculateNextSeatState(currentState, rowNumber, seatNumber, occupiedLimit, rule);
                }

                nextState.Add(nextRow);
            }

            return nextState;
        }

        private static char CalculateNextSeatState(
            List<string> currentState, int rowNumber, int seatNumber, int occupiedLimit, OccupiedRule rule)
        {
            var currentSeat = currentState[rowNumber][seatNumber];
            int occupiedSeats;

            switch (currentSeat)
            {
                case '.':
                    return '.';
                case 'L':
                    occupiedSeats = (rule == OccupiedRule.Adjacent)
                        ? CountAdjacentOccupiedSeats(currentState, rowNumber, seatNumber)
                        : CountLineOfSightOccupiedSeats(currentState, rowNumber, seatNumber);
                    return occupiedSeats == 0 ? '#' : 'L';
                case '#':
                    occupiedSeats = (rule == OccupiedRule.Adjacent)
                        ? CountAdjacentOccupiedSeats(currentState, rowNumber, seatNumber)
    :                   CountLineOfSightOccupiedSeats(currentState, rowNumber, seatNumber);
                    return occupiedSeats >= occupiedLimit ? 'L' : '#';
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

        public static int CountLineOfSightOccupiedSeats(List<string> currentState, int rowNumber, int seatNumber)
        {
            int occupiedSeats = 0;
            int maxRow = currentState.Count;
            int maxSeat = currentState[0].Length;

            int i, j;

            # region right
            j = seatNumber + 1;
            while (j < maxSeat)
            {
                if (currentState[rowNumber][j] == 'L')
                {
                    break;
                }

                if (currentState[rowNumber][j] == '#')
                {
                    occupiedSeats++;
                    break;
                }

                j++;
            }
            #endregion

            #region left
            j = seatNumber - 1;
            while (j >= 0)
            {
                if (currentState[rowNumber][j] == 'L')
                {
                    break;
                }

                if (currentState[rowNumber][j] == '#')
                {
                    occupiedSeats++;
                    break;
                }

                j--;
            }
            #endregion

            #region top
            i = rowNumber - 1;
            while (i >= 0)
            {
                if (currentState[i][seatNumber] == 'L')
                {
                    break;
                }

                if (currentState[i][seatNumber] == '#')
                {
                    occupiedSeats++;
                    break;
                }

                i--;
            }
            #endregion

            #region bottom
            i = rowNumber + 1;
            while (i < maxRow)
            {
                if (currentState[i][seatNumber] == 'L')
                {
                    break;
                }

                if (currentState[i][seatNumber] == '#')
                {
                    occupiedSeats++;
                    break;
                }

                i++;
            }
            #endregion

            #region bottom-right
            i = rowNumber + 1;
            j = seatNumber + 1;

            while (i < maxRow && j < maxSeat)
            {
                if (currentState[i][j] == 'L')
                {
                    break;
                }

                if (currentState[i][j] == '#')
                {
                    occupiedSeats++;
                    break;
                }

                i++;
                j++;
            }
            #endregion

            #region bottom-left
            i = rowNumber + 1;
            j = seatNumber - 1;

            while (i < maxRow && j >= 0)
            {
                if (currentState[i][j] == 'L')
                {
                    break;
                }

                if (currentState[i][j] == '#')
                {
                    occupiedSeats++;
                    break;
                }

                i++;
                j--;
            }
            #endregion

            #region top-right
             i = rowNumber - 1;
            j = seatNumber + 1;

            while (i >= 0 && j < maxSeat)
            {
                if (currentState[i][j] == 'L')
                {
                    break;
                }

                if (currentState[i][j] == '#')
                {
                    occupiedSeats++;
                    break;
                }

                i--;
                j++;
            }
            #endregion

            #region top-left
            i = rowNumber - 1;
            j = seatNumber - 1;

            while (i >= 0 && j >= 0)
            {
                if (currentState[i][j] == 'L')
                {
                    break;
                }

                if (currentState[i][j] == '#')
                {
                    occupiedSeats++;
                    break;
                }

                i--;
                j--;
            }
            #endregion

            return occupiedSeats;
        }
    }
}
