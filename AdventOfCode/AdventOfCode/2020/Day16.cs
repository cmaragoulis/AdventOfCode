using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day16
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day16.txt";

        public static int Problem1()
        {
            int answer = 0;
            var input = File.ReadAllLines(inputPath).ToList();

            var indexOfFirstBreak = input.IndexOf(string.Empty);
            var indexOfSecondBreak = input.LastIndexOf(string.Empty);

            var fieldRangesInput = input.Take(indexOfFirstBreak);
            var myTicket = input[indexOfFirstBreak + 2];
            var nearbyTicketsInput = input.Skip(indexOfSecondBreak + 2);

            var uniqueNumbers = new HashSet<int>();

            var fieldRanges = GetFieldRanges(fieldRangesInput);

            foreach (var fieldRange in fieldRanges.Values)
            {
                for (int i = fieldRange.Item1; i <= fieldRange.Item2; i++)
                {
                    uniqueNumbers.Add(i);
                }

                for (int i = fieldRange.Item3; i <= fieldRange.Item4; i++)
                {
                    uniqueNumbers.Add(i);
                }
            }

            foreach (var ticket in nearbyTicketsInput)
            {
                var ticketValues = ticket.Split(',').Select(d => int.Parse(d));

                foreach (var value in ticketValues)
                {
                    if (!uniqueNumbers.Contains(value))
                    {
                        answer += value;
                    }
                }
            }

            return answer;
        }

        //this needs some SERIOUS refactoring but at least it's working
        public static long Problem2()
        {
            var input = File.ReadAllLines(inputPath).ToList();

            var indexOfFirstBreak = input.IndexOf(string.Empty);
            var indexOfSecondBreak = input.LastIndexOf(string.Empty);

            var fieldRangesInput = input.Take(indexOfFirstBreak);
            var myTicket = input[indexOfFirstBreak + 2];
            var myTicketValues = myTicket.Split(',').Select(t => int.Parse(t)).ToList();
            var nearbyTicketsInput = input.Skip(indexOfSecondBreak + 2);

            var fieldRanges = GetFieldRanges(fieldRangesInput);
            var validTickets = GetValidTickets(nearbyTicketsInput, fieldRanges);

            var fieldMap = new Dictionary<int, List<string>>();
            
            //start by assigning to each ticket field a list of all possible field values
            for (int i = 0; i < myTicketValues.Count; i++)
            {
                fieldMap[i] = fieldRanges.Keys.ToList();
            }

            //then loop through all tickets and all ticket values and remove incompatible fields
            foreach (var ticket in validTickets)
            {
                for (int i = 0; i < ticket.Count; i++)
                {
                    var fieldValue = ticket[i];

                    foreach (var fieldRange in fieldRanges)
                    {
                        if (
                            (fieldValue >= fieldRange.Value.Item1 && fieldValue <= fieldRange.Value.Item2)
                            || (fieldValue >= fieldRange.Value.Item3 && fieldValue <= fieldRange.Value.Item4)
                            )
                        {
                            continue;
                        }
                        else
                        {
                            fieldMap[i].Remove(fieldRange.Key);
                        }

                    }
                }
            }

            //find values with only 1 possible field and then remove that field from all
            //other values. Repeat until every value has only 1 field associated with it
            var determinedFields = new List<string>
            {
                fieldMap.First(fieldMap => fieldMap.Value.Count == 1).Value.First()
            };

            while (fieldMap.Any(fm => fm.Value.Count > 1))
            {
                foreach (var item in fieldMap)
                {
                    if (item.Value.Count > 1)
                    {
                        item.Value.Remove(determinedFields.Last());
                    }
                }

                var nextDetermined = fieldMap.First(_ => _.Value.Count == 1 && !determinedFields.Contains(_.Value[0])).Value[0];
                determinedFields.Add(nextDetermined);
            }
            
            var finalMap = fieldMap.ToDictionary(k => k.Key, v => v.Value[0]);

            long answer = 1;
            foreach (var item in finalMap.Where(_ => _.Value.StartsWith("departure")))
            {
                answer *= myTicketValues[item.Key];
            }

            return answer;
        }

        private static Dictionary<string, (int, int, int, int)> GetFieldRanges(IEnumerable<string> valueRanges)
        {
            var fieldRanges = new Dictionary<string, (int, int, int, int)>();

            foreach (var line in valueRanges)
            {
                var match = Regex.Match(line, @"([\w\s]+): (\d+)-(\d+) or (\d+)-(\d+)");

                fieldRanges[match.Groups[1].Value] = (
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value),
                    int.Parse(match.Groups[4].Value),
                    int.Parse(match.Groups[5].Value)
                    );
            }

            return fieldRanges;
        }

        private static List<List<int>> GetValidTickets(
            IEnumerable<string> tickets, Dictionary<string, (int, int, int, int)> fieldRanges)
        {
            var validTickets = new List<List<int>>();

            foreach (var ticket in tickets)
            {
                var ticketValues = ticket.Split(',').Select(d => int.Parse(d)).ToList();

                //is valid if:
                //for ALL ticket values
                //exists ANY field
                //where that value is between one of the two ranges of the field
                var isValid = ticketValues
                    .All(v =>
                        fieldRanges.Values
                            .Any(f =>
                                (v >= f.Item1 && v <= f.Item2) || (v >= f.Item3 && v <= f.Item4)
                            )
                    );

                if (isValid)
                {
                    validTickets.Add(ticketValues);
                }
            }

            return validTickets;
        }
    }
}
