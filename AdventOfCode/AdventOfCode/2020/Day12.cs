using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{

    public class Day12
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day12.txt";

        public static int Problem1()
        {
            var instructions = File.ReadAllLines(inputPath).ToList();

            var ferry = new Ferry(Direction.E);

            foreach (var instruction in instructions)
            {
                var command = instruction[0].ToString();
                var units = int.Parse(instruction[1..]);

                if (command == "F")
                {
                    ferry.Forward(units);
                }
                else if (command == "R" || command == "L")
                {
                    ferry.Turn(command, units);
                }
                else
                {
                    ferry.Move(command, units);
                }
            }

            var answer = Math.Abs(ferry.X) + Math.Abs(ferry.Y);

            return answer;
        }

        public static int Problem2()
        {
            var instructions = File.ReadAllLines(inputPath).ToList();

            var ferry = new Ferry(10, 1);

            foreach (var instruction in instructions)
            {
                var command = instruction[0].ToString();
                var units = int.Parse(instruction[1..]);

                if (command == "F")
                {
                    ferry.MoveToWaypoint(units);
                }
                else if (command == "R" || command == "L")
                {
                    ferry.RotateWaypoing(command, units);
                }
                else
                {
                    ferry.MoveWaypoint(command, units);
                }
            }

            var answer = Math.Abs(ferry.X) + Math.Abs(ferry.Y);

            return answer;
        }
    }


    public enum Direction
    {
        N, S, E, W
    }

    public class Ferry
    {
        public Direction Facing { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int WaypointX { get; set; }
        public int WaypointY { get; set; }

        public Ferry(Direction facing)
        {
            Facing = facing;
        }

        public Ferry(int wayPointX, int wayPointY)
        {
            WaypointX = wayPointX;
            WaypointY = wayPointY;
        }

        public void Forward(int units)
        {
            switch (Facing)
            {
                case Direction.N:
                    X += units;
                    break;
                case Direction.S:
                    X -= units;
                    break;
                case Direction.E:
                    Y += units;
                    break;
                case Direction.W:
                    Y -= units;
                    break;
            }
        }

        public void Turn(string direction, int degrees)
        {
            if (degrees == 270)
            {
                degrees = 90;

                direction = direction == "R" ? "L" : "R";
            }

            if (degrees == 90)
            {
                if (direction == "R")
                {
                    switch (Facing)
                    {
                        case Direction.N:
                            Facing = Direction.E;
                            break;
                        case Direction.S:
                            Facing = Direction.W;
                            break;
                        case Direction.E:
                            Facing = Direction.S;
                            break;
                        case Direction.W:
                            Facing = Direction.N;
                            break;
                    }
                }

                if (direction == "L")
                {
                    switch (Facing)
                    {
                        case Direction.N:
                            Facing = Direction.W;
                            break;
                        case Direction.S:
                            Facing = Direction.E;
                            break;
                        case Direction.E:
                            Facing = Direction.N;
                            break;
                        case Direction.W:
                            Facing = Direction.S;
                            break;
                    }
                }
            }
            else if (degrees == 180)
            {
                switch (Facing)
                {
                    case Direction.N:
                        Facing = Direction.S;
                        break;
                    case Direction.S:
                        Facing = Direction.N;
                        break;
                    case Direction.E:
                        Facing = Direction.W;
                        break;
                    case Direction.W:
                        Facing = Direction.E;
                        break;
                }
            }
        }

        public void Move(string direction, int units)
        {
            switch (direction)
            {
                case "N":
                    X += units;
                    break;
                case "S":
                    X -= units;
                    break;
                case "E":
                    Y += units;
                    break;
                case "W":
                    Y -= units;
                    break;
            }
        }

        public void MoveWaypoint(string direction, int units)
        {
            switch (direction)
            {
                case "N":
                    WaypointY += units;
                    break;
                case "S":
                    WaypointY -= units;
                    break;
                case "E":
                    WaypointX += units;
                    break;
                case "W":
                    WaypointX -= units;
                    break;
            }
        }

        public void MoveToWaypoint(int units)
        {
            var relativeX = Math.Abs(X - WaypointX);
            var relativeY = Math.Abs(Y - WaypointY);

            int xSign = WaypointX > X ? 1 : -1;
            int ySign = WaypointY > Y ? 1 : -1;

            X += units * relativeX * xSign;
            Y += units * relativeY * ySign;

            WaypointX = X + (xSign * relativeX);
            WaypointY = Y + (ySign * relativeY);
        }

        public void RotateWaypoing(string direction, int degrees)
        {
            if (degrees == 270)
            {
                degrees = 90;
                direction = direction == "R" ? "L" : "R";
            }

            if (degrees == 180)
            {
                WaypointX += -X;
                WaypointY += -Y;

                WaypointX = -WaypointX;
                WaypointY = -WaypointY;

                WaypointX += X;
                WaypointY += Y;
            }

            if (degrees == 90)
            {
                if (direction == "R")
                {
                    WaypointX += -X;
                    WaypointY += -Y;

                    int temp = WaypointX;
                    WaypointX = WaypointY;
                    WaypointY = -temp;

                    WaypointX += X;
                    WaypointY += Y;
                }
                else
                {
                    WaypointX += -X;
                    WaypointY += -Y;

                    int temp = WaypointY;
                    WaypointY = WaypointX;
                    WaypointX = -temp;

                    WaypointX += X;
                    WaypointY += Y;
                }
            }
        }
    }
}
