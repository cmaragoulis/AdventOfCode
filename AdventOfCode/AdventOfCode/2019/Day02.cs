using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    enum Opcode
    {
        Add = 1,
        Multiply = 2,
        Terminate = 99
    }

    public class Day02
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2019\Inputs\Day02.txt";

        public static int Problem1()
        {
            var input = File.ReadAllText(inputPath);
            int[] program = input
                .Split(',')
                .Select(s => int.Parse(s))
                .ToArray();

            //Restore program to 1202 alarm state
            program[1] = 12;
            program[2] = 2;

            var output = ExecuteProgram(program);

            return output[0];
        }

        public static int Problem2()
        {
            var input = File.ReadAllText(inputPath);
            int[] program = input
                .Split(',')
                .Select(s => int.Parse(s))
                .ToArray();

            int expectedResult = 19690720;

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    int[] programCopy = new int[program.Length];
                    program.CopyTo(programCopy, 0);

                    programCopy[1] = noun;
                    programCopy[2] = verb;

                    var output = ExecuteProgram(programCopy);

                    if (output[0] == expectedResult)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return -1;
        }

        public static int[] ExecuteProgram(string input)
        {
            int[] program = input
                    .Split(',')
                    .Select(s => int.Parse(s))
                    .ToArray();

            return ExecuteProgram(program);
        }

        public static int[] ExecuteProgram(int[] program)
        {
            var cursor = 0;
            while ((Opcode)program[cursor] != Opcode.Terminate)
            {
                var leftInput = program[cursor + 1];
                var rightInput = program[cursor + 2];
                var output = program[cursor + 3];

                switch ((Opcode)program[cursor])
                {
                    case Opcode.Add:
                        program[output] = program[leftInput] + program[rightInput];
                        break;
                    case Opcode.Multiply:
                        program[output] = program[leftInput] * program[rightInput];
                        break;
                }

                cursor += 4;
            }

            return program;
        }
    }
}
