using System;
using System.Diagnostics;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            var sw = Stopwatch.StartNew();


            var answer = AdventOfCode2020.Day21.Problem1();
            
            sw.Stop();

            Console.WriteLine($"The answer is {answer}{Environment.NewLine}Time: {sw.ElapsedMilliseconds}ms");
        }
    }
}
