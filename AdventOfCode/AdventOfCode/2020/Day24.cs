using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day24
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day24.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            var floorTiles = InitializeFloor(input);

            var blackTiles = floorTiles.Count(t => t.Value == true);

            return blackTiles;
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            var startingFloor = InitializeFloor(input);

            var finalFloor = GetFinalState(startingFloor, 100);

            var blackTiles = finalFloor.Count(t => t.Value == true);

            return blackTiles;
        }


        public static Dictionary<(decimal x, decimal y), bool> InitializeFloor(string[] instructions)
        {
            var floorTiles = new Dictionary<(decimal x, decimal y), bool>()
            {
                {(0, 0) , false}
            };

            foreach (var line in instructions)
            {
                var tileCoordinates = GetTileCoordinates(line);

                if (floorTiles.ContainsKey(tileCoordinates))
                {
                    floorTiles[tileCoordinates] = !floorTiles[tileCoordinates];
                }
                else
                {
                    floorTiles.Add(tileCoordinates, true);
                }
            }

            return floorTiles;
        }

        public static Dictionary<(decimal x, decimal y), bool> GetFinalState(
            Dictionary<(decimal x, decimal y), bool> startingFloor, int days)
        {
            var nextFloor = new Dictionary<(decimal x, decimal y), bool>(startingFloor);

            for (int i = 0; i < days; i++)
            {
                var currentFloor = new Dictionary<(decimal x, decimal y), bool>(nextFloor);

                nextFloor = GetNextFloor(currentFloor);
            }

            return nextFloor;
        }

        private static (decimal x, decimal y) GetTileCoordinates(string path)
        {
            decimal x = 0;
            decimal y = 0;
            string move = string.Empty;

            foreach (var letter in path)
            {
                move += letter;

                switch (move)
                {
                    case "e":
                        x--;
                        move = string.Empty;
                        break;
                    case "se":
                        x -= 0.5m;
                        y -= 1;
                        move = string.Empty;
                        break;
                    case "sw":
                        x += 0.5m;
                        y -= 1;
                        move = string.Empty;
                        break;
                    case "w":
                        x++;
                        move = string.Empty;
                        break;
                    case "nw":
                        x += 0.5m;
                        y += 1;
                        move = string.Empty;
                        break;
                    case "ne":
                        x -= 0.5m;
                        y += 1;
                        move = string.Empty;
                        break;
                }
            }

            return (x, y);
        }

        public static List<(decimal x, decimal y)> GetNeighbors(decimal x, decimal y) =>
            new List<(decimal x, decimal y)>
            {
                (x+1, y),
                (x+0.5m, y+1),
                (x-0.5m, y+1),
                (x-1, y),
                (x-0.5m, y-1),
                (x+0.5m, y-1),
            };

        private static Dictionary<(decimal x, decimal y), bool> GetNextFloor(
            Dictionary<(decimal x, decimal y), bool> currentFloor)
        {
            AddBorderNeighbors(currentFloor);

            var nextFloor = new Dictionary<(decimal x, decimal y), bool>(currentFloor);

            foreach (var tile in currentFloor)
            {
                var blackNeighbors = 0;
                var neighbors = GetNeighbors(tile.Key.x, tile.Key.y);

                foreach (var neighbor in neighbors)
                {
                    if (currentFloor.ContainsKey(neighbor))
                    {
                        blackNeighbors += currentFloor[neighbor] ? 1 : 0;
                    }
                    else
                    {
                        nextFloor[neighbor] = false;
                    }
                }

                if (!tile.Value && blackNeighbors == 2)
                {
                    nextFloor[tile.Key] = true;
                }

                if (tile.Value && (blackNeighbors == 0 || blackNeighbors > 2))
                {
                    nextFloor[tile.Key] = false;
                }
            }

            return nextFloor;
        }

        private static void AddBorderNeighbors(
            Dictionary<(decimal x, decimal y), bool> floor)
        {
            var borderNeighbors = new HashSet<(decimal x, decimal y)>();

            foreach (var tile in floor)
            {
                foreach (var neighbor in GetNeighbors(tile.Key.x, tile.Key.y))
                {
                    if (floor.ContainsKey(neighbor))
                    {
                        continue;
                    }
                    else
                    {
                        borderNeighbors.Add(neighbor);
                    }
                }
            }
            
            foreach (var borderNeighbor in borderNeighbors)
            {
                floor[borderNeighbor] = false;
            }
        }
    }
}
