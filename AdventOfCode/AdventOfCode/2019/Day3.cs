using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public enum Direction
    {
        Up = 'U',
        Down = 'D',
        Left = 'L',
        Right = 'R'
    }

    public enum ClosestCriterion
    {
        Distance, Steps
    }

    public class Day3
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2019\Inputs\Day3.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            string wire1 = input[0];
            string wire2 = input[1];

            return CalculateClosestIntersection(wire1, wire2, ClosestCriterion.Distance);
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            string wire1 = input[0];
            string wire2 = input[1];

            //11355 is too low
            return CalculateClosestIntersection(wire1, wire2, ClosestCriterion.Steps);
        }

        public static int CalculateClosestIntersection(string wire1, string wire2, ClosestCriterion closestCriterion)
        {
            var wire1Coordinates = TraverseWirePath(wire1);
            var wire2Coordinates = TraverseWirePath(wire2);
            var minCriterion = int.MaxValue;

            var intersections = wire1Coordinates
                .Intersect(wire2Coordinates, new CoordinateEqualityComparer())
                .ToList();

            foreach (var intersection in intersections)
            {
                int criterion = int.MaxValue;
                switch (closestCriterion)
                {
                    case ClosestCriterion.Distance:
                        criterion = Math.Abs(intersection.x) + Math.Abs(intersection.y);
                        break;
                    case ClosestCriterion.Steps:
                        criterion = wire1Coordinates.First(c => c.x == intersection.x && c.y == intersection.y).steps
                            + wire2Coordinates.First(c => c.x == intersection.x && c.y == intersection.y).steps;
                        break;
                }

                if (criterion < minCriterion)
                {
                    minCriterion = criterion;
                }
            }

            return minCriterion;
        }

        private static List<(int x, int y, int steps)> TraverseWirePath(string wirePath)
        {
            List<(int, int, int)> wireCoordinates = new List<(int, int, int)>();
            var moves = wirePath.Split(',').ToArray();

            var coordinates = (x: 0, y: 0, steps: 0);
            foreach (var move in moves)
            {
                var direction = (Direction)move[0];
                var steps = int.Parse(move[1..]);

                switch (direction)
                {
                    case Direction.Up:
                        for (int i = 0; i < steps; i++)
                        {
                            coordinates.steps++;
                            coordinates.y++;
                            wireCoordinates.Add(coordinates);
                        }
                        break;
                    case Direction.Down:
                        for (int i = 0; i < steps; i++)
                        {
                            coordinates.steps++;
                            coordinates.y--;
                            wireCoordinates.Add(coordinates);
                        }
                        break;
                    case Direction.Left:
                        for (int i = 0; i < steps; i++)
                        {
                            coordinates.steps++;
                            coordinates.x--;
                            wireCoordinates.Add(coordinates);
                        }
                        break;
                    case Direction.Right:
                        for (int i = 0; i < steps; i++)
                        {
                            coordinates.steps++;
                            coordinates.x++;
                            wireCoordinates.Add(coordinates);
                        }
                        break;
                }
            }

            return wireCoordinates;
        }

        public class CoordinateEqualityComparer : IEqualityComparer<(int x, int y, int steps)>
        {
            public bool Equals((int x, int y, int steps) c1, (int x, int y, int steps) c2)
            {
                return c1.x == c2.x && c1.y == c2.y;
            }

            public int GetHashCode([DisallowNull] (int x, int y, int steps) c)
            {
                return c.x ^ c.y;
            }
        }
    }
}
