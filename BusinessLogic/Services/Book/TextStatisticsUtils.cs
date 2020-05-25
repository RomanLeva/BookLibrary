using System;
using System.Linq;
using System.Text;

namespace BusinessLogic.Mappings
{
    public static class TextStatisticsUtils
    {
        private static readonly char[] _delimiterChars = { ' ', ',', '.', ':', ';', '\n','\t', '?', '!', '"', '\'' };
        private static readonly char[] _delimiterCharsSentences = { '.', '?', '!' };

        public static string GetStatisticString(string text)
        {
            if (text == null) return "<text is null>";

            var sb = new StringBuilder();
            sb.Append("Text length: ").Append(TextStatisticsUtils.TextLength(text)).AppendLine();
            sb.Append("Words count: ").Append(TextStatisticsUtils.WordsCount(text)).AppendLine();
            sb.Append("Unique words: ").Append(TextStatisticsUtils.UniqueWordsCount(text)).AppendLine();
            sb.Append("Middle word length: ").Append(TextStatisticsUtils.AverageWordLegth(text)).AppendLine();
            sb.Append("Middle sentence length: ").Append(TextStatisticsUtils.MiddleSentenceLength(text)).AppendLine();

            return sb.ToString();
        }

        public static int TextLength(string text)
        {
            if (text == null) return 0;
            return text.Length;
        }

        public static int WordsCount(string text)
        {
            if (text == null) return 0;
            var words = text.Split(_delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            return words.Count();
        }

        public static int UniqueWordsCount(string text)
        {
            if (text == null) return 0;
            var words = text.Split(_delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            return words.Count();
        }

        public static double AverageWordLegth(string text)
        {
            if (text == null) return 0;
            var words = text.Split(_delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            double average = words.Sum(word => word.Length) / words.Count();
            return Math.Round(average, 1);
        }

        public static double MiddleSentenceLength(string text)
        {
            if (text == null) return 0;
            var sentences = text.Split(_delimiterCharsSentences, StringSplitOptions.RemoveEmptyEntries);
            double average = sentences.Sum(sentence => WordsCount(sentence)) / sentences.Count();
            return Math.Round(average, 1);
        }
    }
}
