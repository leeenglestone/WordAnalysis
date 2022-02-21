using System;
using System.Collections.Generic;
using System.Linq;

namespace WordAnalysis.ConsoleApplication
{
    public class Analysis
    {
        public static List<Letter> AnalyseWords(List<string> words, int totalWords)
        {
            var _letters = new List<Letter>();

            foreach (var letter in GetLetters())
            {
                _letters.Add(new Letter()
                {
                    Value = letter.ToLower(),
                    StartingWith = StartingWithCount(letter, words),
                    StartingWithPercentage = StartingWithPercentage(letter, totalWords, words),
                    EndingWith = EndingWithCount(letter, words),
                    EndingWithPercentage = EndingWithPercentage(letter, totalWords, words),
                    DoubleLetters = DoubleLetterCount(letter, words)
                });
            }

            return _letters;
        }

        public static IEnumerable<string> FindWords(string includingLetters, List<string> words)
        {
            var matchingWords = new List<string>();

            Console.WriteLine();
            Console.WriteLine($"== Solving ({includingLetters.ToUpper()}) ==");

            var match = true;

            foreach (var word in words)
            {
                match = true;

                //if (word.Length != includingLetters.Length)
                //{
                //    match = false;
                //    continue;
                //}

                foreach (var letter in includingLetters)
                {
                    if (!word.Contains(letter))
                    {
                        match = false;
                        continue;
                    }
                }

                if (match)
                {
                    matchingWords.Add(word.ToUpper());
                    Console.WriteLine(word.ToUpper());
                }
            }

            return matchingWords;
        }

        public static IEnumerable<string> FindWords(
            string includingLetters,
            string excludingLetters,
            string pattern,
            List<Tuple<int, char>> lettersNotAtPosition,
            List<string> allWords)
        {
            var matchingWords = new List<string>();

            Console.WriteLine();
            Console.WriteLine($"== Solving ({includingLetters.ToUpper()}) ==");

            var match = true;

            // For every word
            foreach (var word in allWords)
            {
                match = true;

                /*
                if (word.Length != includingLetters.Length)
                {
                    match = false;
                    continue;
                }
                */

                // Filter included letters (must include these)
                foreach (var letter in includingLetters)
                {
                    if (!word.Contains(letter))
                    {
                        match = false;
                        continue;
                    }
                }

                // Filter excluded letters (cannot include these)
                foreach (var letter in excludingLetters)
                {
                    if (word.Contains(letter))
                    {
                        match = false;
                        continue;
                    }
                }

                // Filter known pattern
                for (int x = 0; x < 5; x++)
                {
                    if (pattern[x] == 'X')
                        continue;

                    if (pattern[x] != word[x])
                    {
                        match = false;
                        continue;
                    }
                }

                // Filter valid letters known not to be at positions
                foreach (var item in lettersNotAtPosition)
                {
                    if (word[item.Item1] == item.Item2)
                    {
                        match = false;
                        continue;
                    }
                }

                if (match)
                {
                    matchingWords.Add(word.ToUpper());
                    Console.WriteLine(word.ToUpper());
                }
            }

            return matchingWords;
        }

        private static double EndingWithPercentage(string letter, int totalWords, List<string> words)
        {
            return ((double)EndingWithCount(letter, words) / (double)totalWords) * 100;
        }

        private static double StartingWithPercentage(string letter, int totalWords, List<string> words)
        {
            return ((double)StartingWithCount(letter, words) / (double)totalWords) * 100;
        }

        static int StartingWithCount(string letter, List<string> words)
        {
            return words.Count(x => x.StartsWith(letter));
        }

        static int EndingWithCount(string letter, List<string> words)

        {
            return words.Count(x => x.EndsWith(letter));
        }

        static int DoubleLetterCount(string letter, List<string> words)
        {
            return words.Count(x => x.Contains($"{letter}{letter}"));
        }

        public static string[] GetLetters()
        {
            return new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        }
    }
}
