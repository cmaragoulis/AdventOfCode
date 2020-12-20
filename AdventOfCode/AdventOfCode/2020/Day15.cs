using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day15
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day15.txt";

        public static int Problem1()
        {
            var startingNumbers = File.ReadAllLines(inputPath)
                .First()
                .Split(',')
                .Select(n => int.Parse(n))
                .ToList();

            var answer = PlayMemoryGame(startingNumbers, 2020);

            return answer;
        }

        public static int Problem2()
        {
            var startingNumbers = File.ReadAllLines(inputPath)
                .First()
                .Split(',')
                .Select(n => int.Parse(n))
                .ToList();

            var answer = PlayMemoryGame(startingNumbers, 30000000);

            return answer;
        }

        public static int PlayMemoryGame(List<int> startingNumbers, int rounds)
        {
            int turn = 0;
            var spokenNumbers = new Dictionary<int, FixedSizeQueue<int>>();

            foreach (var number in startingNumbers)
            {
                turn++;
                spokenNumbers[number] = new FixedSizeQueue<int>(2);
                spokenNumbers[number].Enqueue(turn);
            }

            if (!spokenNumbers.ContainsKey(0))
            {
                spokenNumbers[0] = new FixedSizeQueue<int>(2);
            }

            int lastNumber = startingNumbers.Last();

            while (turn < rounds)
            {
                turn++;

                if (spokenNumbers[lastNumber].Count == 1)
                {
                    spokenNumbers[0].Enqueue(turn);
                    lastNumber = 0;
                }
                else
                {
                    var newNumber = spokenNumbers[lastNumber][1] - spokenNumbers[lastNumber][0];

                    if (!spokenNumbers.ContainsKey(newNumber))
                    {
                        spokenNumbers[newNumber] = new FixedSizeQueue<int>(2);
                    }

                    spokenNumbers[newNumber].Enqueue(turn);
                    lastNumber = newNumber;
                }
            }

            return lastNumber;
        }
    }

    class FixedSizeQueue<T>
    {
        private readonly int Size;
        private readonly List<T> Queue;

        public int Count => Queue.Count;

        public FixedSizeQueue(int size)
        {
            Size = size;
            Queue = new List<T>(size);
        }

        public T this[int index]
        {
            get => Queue[index];
            set => Queue[index] = value;
        }

        public void Enqueue(T element)
        {
            if (Queue.Count == Size)
            {
                Queue.RemoveAt(0);
            }

            Queue.Add(element);
        }
    }
}
