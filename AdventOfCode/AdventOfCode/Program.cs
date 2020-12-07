using System;
using System.Diagnostics;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            var sw = Stopwatch.StartNew();

            var answer = AdventOfCode2020.Day7.Problem2();

            sw.Stop();

            Console.WriteLine($"The answer is {answer}{Environment.NewLine}Time: {sw.ElapsedMilliseconds}ms");
        }
    }
}
