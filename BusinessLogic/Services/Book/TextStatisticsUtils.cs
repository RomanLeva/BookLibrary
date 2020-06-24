using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Services
{
    public static class TextStatisticsUtils
    {
        private static readonly char[] DelimiterChars = { ' ', ',', '.', ':', ';', '\n','\t', '?', '!', '"', '\'' };
        private static readonly char[] DelimiterCharsSentences = { '.', '?', '!' };

        public static int TextLength(string text)
        {
            if (text == null)
            {
                return 0;
            }

            return text.Length;
        }

        public static int WordsCount(string text)
        {
            if (text == null)
            {
                return 0;
            }
            var words = text.Split(DelimiterChars, StringSplitOptions.RemoveEmptyEntries);

            return words.Count();
        }

        public static int UniqueWordsCount(string text)
        {
            if (text == null)
            {
                return 0;
            }
            var words = text.Split(DelimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var wordsSet = new HashSet<string>();
            foreach(var word in words)
            {
                wordsSet.Add(word);
            }

            return wordsSet.Count();
        }

        public static double AverageWordLength(string text)
        {
            if (text == null)
            {
                return 0;
            }
            var words = text.Split(DelimiterChars, StringSplitOptions.RemoveEmptyEntries);
            double average = words.Sum(word => word.Length) / words.Count();

            return Math.Round(average, 1);
        }

        public static double AverageSentenceLength(string text)
        {
            if (text == null)
            {
                return 0;
            }
            var sentences = text.Split(DelimiterCharsSentences, StringSplitOptions.RemoveEmptyEntries);
            double average = sentences.Sum(sentence => WordsCount(sentence)) / sentences.Count();

            return Math.Round(average, 1);
        }
    }
}
