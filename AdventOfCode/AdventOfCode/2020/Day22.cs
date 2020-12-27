using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day22
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day22.txt";

        public static long Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            ReadInput(input, out List<int> player1, out List<int> player2);

            List<int> winningHand = Combat(player1, player2);

            return CalculateWinnerScore(winningHand);
        }

        public static int Problem2()
        {
            var input = File.ReadAllLines(inputPath);

            ReadInput(input, out List<int> player1, out List<int> player2);


            return -1;
        }


        private static void ReadInput(string[] input, out List<int> player1, out List<int> player2)
        {
            var splitIndex = input.ToList().IndexOf(string.Empty);

            player1 = input[1..splitIndex].Select(c => int.Parse(c)).ToList();
            player2 = input[(splitIndex + 2)..].Select(c => int.Parse(c)).ToList();
        }

        public static List<int> Combat(List<int> player1, List<int> player2)
        {
            while (player1.Count > 0 && player2.Count > 0)
            {
                if (player1[0] > player2[0])
                {
                    player1.Add(player1[0]);
                    player1.Add(player2[0]);
                }
                else
                {
                    player2.Add(player2[0]);
                    player2.Add(player1[0]);
                }

                player1.RemoveAt(0);
                player2.RemoveAt(0);
            }

            return player1.Count > 0 ? player1 : player2;
        }

        public static void RecursiveCombar(List<int> player1, List<int> player2)
        {
            //to do
        }

        public static long CalculateWinnerScore(List<int> winningHand)
        {
            long score = 0;

            for (int i = 0; i < winningHand.Count; i++)
            {
                score += winningHand[i] * (winningHand.Count - i);
            }

            return score;
        }
    }
}
