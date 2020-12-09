using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day9
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day9.txt";

        public static long Problem1()
        {
            var input = File.ReadAllLines(inputPath)
                .Select(l => long.Parse(l))
                .ToList();

            int preamble = 25;

            return FindWeakNumber(preamble, input);
        }

        public static long Problem2()
        {
            var input = File.ReadAllLines(inputPath)
                .Select(l => long.Parse(l))
                .ToList();

            int preamble = 25;

            long weakNumber = FindWeakNumber(preamble, input);


            return FindEncryptionWeakness(input, weakNumber);
        }

        public static long FindWeakNumber(int preamble, List<long> numbers)
        {
            var queue = new Queue<long>(preamble);

            for (int i = 0; i < preamble; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = preamble; i < numbers.Count; i++)
            {
                if (HasSum(queue, numbers[i]))
                {
                    queue.Dequeue();
                    queue.Enqueue(numbers[i]);
                }
                else
                {
                    return numbers[i];
                }
            }

            return -1;
        }

        public static long FindEncryptionWeakness(List<long> numbers, long weakNumber)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int j = i + 1;
                var currentNumbers = new List<long>()
                {
                    numbers[i], numbers[j]
                };
                long currentSum = numbers[i] + numbers[j];

                if (currentSum == weakNumber)
                {
                    return currentSum;
                }

                while (j < numbers.Count && currentSum < weakNumber)
                {
                    j++;
                    currentNumbers.Add(numbers[j]);
                    currentSum += numbers[j];

                    if (currentSum == weakNumber)
                    {
                        return currentNumbers.Min() + currentNumbers.Max();
                    }
                }
            }

            return -1;
        }

        private static bool HasSum(Queue<long> queue, long number)
        {
            for (int i = 0; i < queue.Count - 1; i++)
            {
                for (int j = 0; j < queue.Count; j++)
                {
                    if (queue.ElementAt(i) + queue.ElementAt(j) == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
