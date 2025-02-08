/* !!!
 * DO NOT MODIFY THIS FILE
 * !!!
 */

namespace LuckyNumberGame;

public static class Grader
{
    private const byte MAX_SCORE = 10;

    public static void Main()
    {
        if (File.Exists("inputs.txt") == false)
        {
            Console.Error.WriteLine("ERROR: Input file could not be found! Tell the instructor about this error message ASAP.");
            return;
        }

        String[] lines = File.ReadAllLines("inputs.txt");

        float score = MAX_SCORE;
        float detractor = (float)MAX_SCORE / (lines.Length / 3);

        for (int i = 0; i < lines.Length; i += 3)
        {
            int[] luckyNumbers = lines[i].Split(" ").Select(x => Convert.ToInt32(x)).ToArray();
            (int a, int b) luckyNums = (luckyNumbers[0], luckyNumbers[1]);
            int[] nums = lines[i + 1].Split(" ").Select(x => Convert.ToInt32(x)).ToArray();
            Source.Winner answer = (Source.Winner)Convert.ToInt32(lines[i + 2]);

            Source.Winner studentResult = Source.Solve(luckyNums, nums);

            if (studentResult != answer)
            {
                Console.WriteLine($"Answer for input {(i / 3) + 1} ({studentResult}) was incorrect.");
                score -= detractor;
            }
        }

        Console.WriteLine($"***Final score: {Math.Round(score, 2)}/{MAX_SCORE}");
    }
}
