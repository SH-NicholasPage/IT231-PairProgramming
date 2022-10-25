﻿//DO NOT MODIFY THIS FILE
using System;
using System.IO;
using System.Linq;

namespace BrokenTelephone
{
    public sealed class Program
    {
        private const byte MAX_SCORE = 20;

        public static void Main()
        {
            if(File.Exists("inputs.txt") == false)
            {
                Console.Error.WriteLine("ERROR: Input file could not be found! Tell the instructor about this error message ASAP.");
            }

            String[] lines = File.ReadAllLines("inputs.txt");

            float score = MAX_SCORE;
            float detractor = (float) MAX_SCORE / (lines.Length / 2);

            for(int i = 0; i < lines.Length; i += 2)
            {
                int[] numbers = lines[i].Split(" ").Select(x => Convert.ToInt32(x)).ToArray();
                int answer = Convert.ToInt32(lines[i + 1]);

                int studentResult = Source.Solve(numbers);

                if(studentResult != answer)
                {
                    Console.WriteLine($"Answer for input {(i/2) + 1} ({studentResult}) was incorrect.");
                    score -= detractor;
                }
            }

            Console.WriteLine($"***Final score: {Math.Round(score, 2)}/{MAX_SCORE}");
        }
    }
}