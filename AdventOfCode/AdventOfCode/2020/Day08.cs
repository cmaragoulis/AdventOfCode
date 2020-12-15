using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day08
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day08.txt";

        public static int Problem1()
        {
            var input = File.ReadAllLines(inputPath);
            var program = ParseInput(input);

            return ExecuteProgram(program);
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);
            var program = ParseInput(input);

            FixCorruptProgram(program);

            return ExecuteProgram(program);
        }

        public static List<Command> ParseInput(string[] input)
        {
            var program = new List<Command>();

            foreach (var line in input)
            {
                var match = Regex.Match(line, @"(?<opp>\w{3}) (?<arg>[+-]\d+)");

                Enum.TryParse(match.Groups["opp"].Value, out Operation opp);
                var arg = int.Parse(match.Groups["arg"].Value);

                program.Add(new Command
                {
                    Operation = opp,
                    Argument = arg
                });
            }

            return program;
        }

        public static int ExecuteProgram(List<Command> program)
        {
            int acc = 0;

            int commandIndex = 0;
            while (true)
            {
                if (commandIndex >= program.Count || program[commandIndex].IsExecuted)
                {
                    break;
                }

                var command = program[commandIndex];
                command.IsExecuted = true;
                switch (command.Operation)
                {
                    case Operation.nop:
                        commandIndex++;
                        break;
                    case Operation.acc:
                        acc += command.Argument;
                        commandIndex++;
                        break;
                    case Operation.jmp:
                        commandIndex += command.Argument;
                        break;
                }
            }

            return acc;
        }

        public static void FixCorruptProgram(List<Command> program)
        {
            if (!HasInfiniteLoop(program))
            {
                return;
            }

            for (int i = 0; i < program.Count; i++)
            {
                //skip acc operations
                if (program[i].Operation == Operation.acc)
                {
                    continue;
                }

                //invert operation jmp <-> nop
                InvertOperation(program, i);

                //if changed program has loop, revert change
                //else program has been fixed so return
                if (HasInfiniteLoop(program))
                {
                    InvertOperation(program, i);
                }
                else
                {
                    return;
                }
            }
        }

        private static void InvertOperation(List<Command> program, int position)
        {
            if (program[position].Operation == Operation.acc)
            {
                throw new ArgumentException("Cannot invert acc operations");
            }

            program[position].Operation =
                        program[position].Operation == Operation.jmp
                        ? Operation.nop
                        : Operation.jmp;
        }

        private static bool HasInfiniteLoop(List<Command> program)
        {
            var flag = false;
            int commandIndex = 0;
            while (true)
            {
                if (commandIndex >= program.Count)
                {
                    break;
                }

                if (program[commandIndex].IsExecuted)
                {
                    flag = true;
                    break;
                }

                var command = program[commandIndex];

                switch (command.Operation)
                {
                    case Operation.jmp:
                        commandIndex += command.Argument;
                        break;
                    default:
                        commandIndex++;
                        break;
                }

                command.IsExecuted = true;
            }

            //restore program to mint condition
            program.ForEach(c => c.IsExecuted = false);

            return flag;
        }
    }

    public class Command
    {
        public Operation Operation { get; set; }
        public int Argument { get; set; }
        public bool IsExecuted { get; set; }

        public override string ToString()
        {
            return $"{Operation} {Argument}";
        }
    }

    public enum Operation
    {
        nop, acc, jmp
    }
}
