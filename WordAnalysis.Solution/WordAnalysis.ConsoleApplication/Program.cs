using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordAnalysis.ConsoleApplication
{
    class Program
    {
        static List<string> _words = new List<string>();
        static List<Letter> _letters = new List<Letter>();
        static SortedDictionary<int, int> _wordLengthFrequency = new SortedDictionary<int, int>();
        static SortedDictionary<string, int> _letterFrequency = new SortedDictionary<string, int>();
        static SortedDictionary<string, int> _doubleLetterFrequency = new SortedDictionary<string, int>();
        static int _totalWords;
        static int _totalLetters;

        static void Main(string[] args)
        {
            ReadFile();

            //_letters = Analysis.AnalyseWords(_words, _totalWords);

            //Output.OutputLetterStartsWith(_letters);
            //Output.OutputLetterEndsWith(_letters);
            //Output.OutputWordLengths(_wordLengthFrequency);
            //Output.OutputLongestWord(_words);
            //Output.OutputLetterFrequency(_letterFrequency, _totalLetters);
            //Output.OutputDoubleLetterFrequency(_letters);
            //Output.OutputWordsEndingWithIng(_words);

            //ChartBuilder.SaveLetterFrequencyChart(_letterFrequency);
            //ChartBuilder.SaveLetterStartingWithChart(_letters);
            //ChartBuilder.SaveLetterEndingWithChart(_letters);
            //ChartBuilder.SaveWordLengthFrequencyChart(_wordLengthFrequency);
            //ChartBuilder.SaveDoubleLetterFrequencyChart(_doubleLetterFrequency);

            //Analysis.FindWords("barnslieu", _words);

            //var possibleWords = Analysis.FindWords("tac", "semph", "XaXXX", _words).ToList();

            List<Tuple<int, char>> lettersNotAtPosition = new List<Tuple<int, char>>();

            lettersNotAtPosition.Add(new Tuple<int, char>(1, 't'));
            lettersNotAtPosition.Add(new Tuple<int, char>(2, 't'));
            lettersNotAtPosition.Add(new Tuple<int, char>(3, 'a'));
            lettersNotAtPosition.Add(new Tuple<int, char>(3, 'c'));

            var possibleWords = Analysis.FindWords("tatca", "spemh", "XaXXX", lettersNotAtPosition, _words).ToList();


            /*
            using (StreamWriter file = new StreamWriter(@"C:\Development\WordAnalysis\WordAnalysis.Solution\WordAnalysis.ConsoleApplication\Data\five-letter-words.txt"))
            {
                foreach (var word in _words)
                {
                    if (word.Length != 5)
                        continue;

                    if (word.Contains("."))
                        continue;

                    if (word.Contains("-"))
                        continue;

                    if (word.Contains("'"))
                        continue;

                    file.WriteLine(word);
                }
            }
            */

            Console.ReadLine();
        }

        static void ReadFile()
        {
            foreach (string word in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/five-letter-words.txt")))
            {
                var wordTrimmedLength = word.Trim().Length;

                // Update Word Length Frequency
                if (_wordLengthFrequency.ContainsKey(wordTrimmedLength))
                {
                    _wordLengthFrequency[wordTrimmedLength]++;
                }
                else
                {
                    _wordLengthFrequency.Add(wordTrimmedLength, 1);
                }

                // Update Letter Frequency
                foreach (var letter in word)
                {
                    var lowercaseLetter = letter.ToString().ToLower();

                    if (_letterFrequency.ContainsKey(lowercaseLetter))
                    {
                        _letterFrequency[lowercaseLetter]++;
                    }
                    else
                    {
                        if (Analysis.GetLetters().Contains(lowercaseLetter))
                            _letterFrequency.Add(lowercaseLetter, 1);
                    }
                }

                // Update Double Letter Frequency
                foreach (var letter in Analysis.GetLetters())
                {
                    if (word.Contains(letter + letter))
                    {
                        if (_doubleLetterFrequency.ContainsKey(letter + letter))
                        {
                            _doubleLetterFrequency[letter + letter]++;
                        }
                        else
                        {
                            _doubleLetterFrequency.Add(letter + letter, 1);
                        }
                    }
                }

                _totalLetters += word.Length;

                _words.Add(word.Trim().ToLower());
            }

            _totalWords = _words.Count();

            Console.WriteLine();
            Console.WriteLine($"Total words: {_totalWords.ToString("N0")}");
            Console.WriteLine($"Total letters: {_totalLetters.ToString("N0")}");
        }
    }
}
