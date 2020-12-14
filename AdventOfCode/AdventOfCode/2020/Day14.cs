using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day14
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day14.txt";

        public static long Problem1()
        {
            var program = File.ReadAllLines(inputPath);

            var answer = ExecuteProgram(program);

            return answer;
        }

        public static long Problem2()
        {
            var program = File.ReadAllLines(inputPath);

            var answer = ExecuteProgramV2(program);

            return answer;
        }

        public static long ExecuteProgram(string[] program)
        {
            var mask = string.Empty;
            var memory = new Dictionary<string, long>();

            foreach (var line in program)
            {
                if (line.StartsWith("mask"))
                {
                    mask = Regex.Match(line, "[X01]+$").Value;
                }
                else
                {
                    var match = Regex.Match(line, @"mem\[(?<address>\d+)\] = (?<value>\d+)");

                    var memoryAddress = match.Groups["address"].Value;
                    var value = int.Parse(match.Groups["value"].Value);

                    var binarystring = Convert.ToString(value, 2);

                    //pad left
                    var difference = mask.Length - binarystring.Length;
                    if (difference > 0)
                    {
                        binarystring = $"{new string('0', difference)}{binarystring}";
                    }

                    var maskedValue = string.Empty;
                    for (int i = 0; i < mask.Length; i++)
                    {
                        maskedValue += (mask[i] != 'X') ? mask[i] : binarystring[i];
                    }

                    memory[memoryAddress] = Convert.ToInt64(maskedValue, 2);
                }
            }

            return memory.Values.Sum();
        }

        public static long ExecuteProgramV2(string[] program)
        {
            var mask = string.Empty;
            var memory = new Dictionary<string, long>();

            foreach (var line in program)
            {
                if (line.StartsWith("mask"))
                {
                    mask = Regex.Match(line, "[X01]+$").Value;
                }
                else
                {
                    var match = Regex.Match(line, @"mem\[(?<address>\d+)\] = (?<value>\d+)");

                    var memoryAddress = int.Parse(match.Groups["address"].Value);
                    var value = int.Parse(match.Groups["value"].Value);

                    var binaryString = Convert.ToString(memoryAddress, 2);

                    //pad left
                    var difference = mask.Length - binaryString.Length;
                    if (difference > 0)
                    {
                        binaryString = $"{new string('0', difference)}{binaryString}";
                    }

                    var maskedAddress = string.Empty;
                    for (int i = 0; i < mask.Length; i++)
                    {
                        switch (mask[i])
                        {
                            case '0':
                                maskedAddress += binaryString[i];
                                break;
                            case '1':
                                maskedAddress += '1';
                                break;
                            case 'X':
                                maskedAddress += 'X';
                                break;
                        }
                    }

                    foreach (var address in GenerateAddresses(maskedAddress))
                    {
                        memory[address] = value;
                    }
                }
            }

            return memory.Values.Sum();
        }

        public static List<string> GenerateAddresses(string maskedAddress)
        {
            List<string> addressesToBeWritten = new List<string>();

            if (maskedAddress.Contains('X'))
            {
                var index = maskedAddress.IndexOf('X');

                addressesToBeWritten
                    .AddRange(GenerateAddresses($"{maskedAddress[0..index]}0{maskedAddress[(index + 1)..]}"));

                addressesToBeWritten
                    .AddRange(GenerateAddresses($"{maskedAddress[0..index]}1{maskedAddress[(index + 1)..]}"));
            }
            else
            {
                addressesToBeWritten.Add(maskedAddress);
            }

            return addressesToBeWritten;
        }
    }
}
