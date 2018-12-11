using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.ConsoleApplication
{
    public class Output
    {
        public static void OutputWordLengths(SortedDictionary<int, int> wordLengthFrequency)
        {
            Console.WriteLine();
            Console.WriteLine("== Word Lengths ==");

            var orderedWordLengths = wordLengthFrequency.OrderByDescending(x => x.Value).ToDictionary(t => t.Key, t => t.Value);

            foreach (var length in wordLengthFrequency)
                Console.WriteLine($"{length.Key} {length.Value.ToString("N0")}");
        }

        public static void OutputLetterFrequency(SortedDictionary<string, int> letterFrequency, int totalLetters)
        {
            Console.WriteLine();
            Console.WriteLine("== Letter Frequency ==");

            var orderedLetterFrequency = letterFrequency.OrderByDescending(x => x.Value).ToDictionary(t => t.Key, t => t.Value);

            foreach (var length in orderedLetterFrequency)
            {
                var percentage = ((double)length.Value / (double)totalLetters) * 100;

                Console.WriteLine($"{length.Key} {length.Value.ToString("N0")} ({percentage.ToString("N1")}%)");
            }
        }

        public static void OutputLetterStartsWith(List<Letter> letters)
        {
            Console.WriteLine();
            Console.WriteLine("== Starting With ==");

            foreach (var letter in letters.OrderByDescending(x => x.StartingWith))
                Console.WriteLine($"{letter.Value} {letter.StartingWith.ToString("N0")} {letter.StartingWithPercentage.ToString("N1")}%");
        }

        public static void OutputLetterEndsWith(List<Letter> letters)
        {
            Console.WriteLine();
            Console.WriteLine("== Ending With ==");

            foreach (var letter in letters.OrderByDescending(x => x.EndingWith))
                Console.WriteLine($"{letter.Value} {letter.EndingWith.ToString("N0")} {letter.EndingWithPercentage.ToString("N1")}%");
        }

        public static void OutputDoubleLetterFrequency(List<Letter> letters)
        {
            Console.WriteLine();
            Console.WriteLine("== Double Letters ==");

            foreach (var letter in letters.OrderByDescending(x => x.DoubleLetters))
                Console.WriteLine($"{letter.Value}{letter.Value} {letter.DoubleLetters.ToString("N0")}");
        }

        public static void OutputLongestWord(List<string> words)
        {
            Console.WriteLine("");
            Console.WriteLine("== Longest Word(s) ==");

            var longestWordLength = words.Max(x => x.Length);
            var longestWords = words.Where(x => x.Length == longestWordLength);

            foreach (var word in longestWords)
            {
                Console.WriteLine($"word ({word.Length} letters)");
                Console.WriteLine($"{word}");
            }
        }

        public static void OutputWordsEndingWithIng(List<string> words)
        {
            Console.WriteLine("");
            Console.WriteLine("== Ending with ING ==");

            var count = words.Count(x => x.EndsWith("ing"));
            Console.WriteLine(count);
        }
    }
}
