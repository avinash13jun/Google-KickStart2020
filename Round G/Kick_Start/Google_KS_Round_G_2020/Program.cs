using System;

namespace Kick_Start
{
    class Program
    {
        public const string K = "KICK";
        public const string S = "START";
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int testCase = 1; testCase <= t; testCase++)
            {
                int matchCount = CheckStart(Console.ReadLine());
                Console.WriteLine($"Case #{testCase}: {matchCount}");
            }
        }

        public static int CheckStart(string input)
        {
            int count = 0;
            int matchfound = -1;
            int previousMatch = 0;
            int previousCount = 0;
            for (int i = 0; i <= input.Length;)
            {
                matchfound = input.IndexOf(S, i);
                if (matchfound > -1)
                {
                    previousCount += CheckKickCount(input, matchfound, previousMatch);
                    count += previousCount;
                    i = matchfound + 1;
                    previousMatch = matchfound;
                }
                else
                    break;
            }

            return count;
        }

        public static int CheckKickCount(string input, int index, int previousMatch)
        {
            int count = 0;
            int matchFound = -1;
            for (int i = previousMatch; i < index;)
            {
                matchFound = input.IndexOf(K, i, index - i);
                if (matchFound > -1)
                {
                    count++;
                    i = matchFound + 1;
                }
                else
                    break;
            }

            return count;
        }
    }
}
