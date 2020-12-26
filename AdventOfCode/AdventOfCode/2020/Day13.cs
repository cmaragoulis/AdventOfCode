using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day13
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day13.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            var earliestEstimate = int.Parse(input[0]);
            var buses = input[1]
                .Split(',')
                .Where(b => b != "x")
                .Select(b => int.Parse(b))
                .ToList();

            var departures = new List<(int time, int bus)>();

            foreach (var bus in buses)
            {
                var previousDeparture = (earliestEstimate / bus) * bus;
                var nextDeparture = previousDeparture + bus;
                departures.Add((nextDeparture, bus));
            }

            var earliestDeparture = departures.Min();
            var answer = (earliestDeparture.time - earliestEstimate) * earliestDeparture.bus;

            return answer;
        }

        public static long Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            var answer = FindEarliestTimestampForContest(input[1]);

            return answer;
        }


        public static long FindEarliestTimestampForContest(string busesString)
        {
            List<string> buses = busesString.Split(',').ToList();
            List<(int busId, int offset)> busOffsets = GetBusOffsets(buses);

            long time;
            long increment = busOffsets[0].busId;
            int busIndex = 1;
            
            for (time = busOffsets[0].busId; busIndex < busOffsets.Count; time += increment)
            {
                var currentBusMatchesTime = 
                    (time + busOffsets[busIndex].offset) % busOffsets[busIndex].busId == 0;

                if (currentBusMatchesTime)
                {
                    increment *= busOffsets[busIndex].busId;
                    busIndex++;
                }
            }

            return time - increment;
        }

        //Initial solution for part two. Should be working (passes all tests) but it's to slow to run to completion
        public static long FindEarliestTimestampForContestBruteForce(string busesString)
        {
            List<string> buses = busesString.Split(',').ToList();
            List<(int busId, int offset)> busOffsets = GetBusOffsets(buses);

            var (maxBus, maxBusOffset) = busOffsets.Max();

            long time = maxBus;

            while (true)
            {
                var firstBusDepartureTime = time - maxBusOffset;


                if (busOffsets.Any(bus => (firstBusDepartureTime + bus.offset) % bus.busId != 0))
                {
                    time += maxBus;
                }
                else
                {
                    return firstBusDepartureTime;
                }
            }
        }

        private static List<(int busId, int offset)> GetBusOffsets(List<string> buses)
        {
            var busOffsets = new List<(int busId, int offset)>();

            for (int i = 0; i < buses.Count; i++)
            {
                if (buses[i] != "x")
                {
                    busOffsets.Add((int.Parse(buses[i]), i));
                }
            }
            return busOffsets;
        }
    }
}
