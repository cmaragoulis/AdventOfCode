using System.IO;

namespace AdventOfCode2020
{
    public class Day25
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day25.txt";

        public static long Problem1()
        {
            var input = File.ReadAllLines(inputPath);

            var cardPublicKey = int.Parse(input[0]);
            var doorPublicKey = int.Parse(input[1]);

            var doorLoopSize = DetermineLoopSize(7, doorPublicKey);

            var encryptionKey = TransformSubject(cardPublicKey, doorLoopSize);

            return encryptionKey;
        }

        public static long TransformSubject(int subject, long loopSize)
        {
            var divider = 20201227;
            long value = 1;

            for (long i = 0; i < loopSize; i++)
            {
                value *= subject;
                value %= divider;
            }

            return value;
        }

        public static long DetermineLoopSize(int subject, int publicKey)
        {
            long loopSize = 0;
            var value = 1;

            while (value != publicKey)
            {
                loopSize++;
                value *= subject;
                value %= 20201227;
            }

            return loopSize;
        }
    }
}
