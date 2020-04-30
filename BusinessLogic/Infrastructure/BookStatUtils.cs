using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Infrastructure
{
    public static class BookStatUtils
    {
        public static string TextLength(string text)
        {
            return text.Length.ToString();
        }

        public static string WordsCount(string text)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '?', '!' };
            string[] words = text.Split(delimiterChars);
            var trimmedwords = new List<string>();
            foreach (var w in words)
            {
                if (!w.Equals("")) trimmedwords.Add(w);
            }
            return trimmedwords.Count().ToString();
        }

        public static string UniqueWordsCount(string text)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '?', '!' };
            string[] words = text.Split(delimiterChars);
            var trimmeduniquewords = new HashSet<string>();
            foreach (var s in words)
            {
                if (!s.Equals(""))
                {
                    trimmeduniquewords.Add(s.Trim(' '));
                }
            }
            return trimmeduniquewords.Count.ToString();
        }

        public static string MiddleWordLegth(string text)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '?', '!' };
            string[] words = text.Split(delimiterChars);
            var trimmedwords = new List<string>();
            foreach (var s in words)
            {
                if (!s.Equals(""))
                {
                    trimmedwords.Add(s.Trim(' '));
                }
            }
            double letters = 0;
            foreach (var s in trimmedwords)
            {
                letters += s.Length;
            }
            double middle = letters / trimmedwords.Count;
            middle = Math.Round(middle, 1);
            return middle.ToString();
        }

        public static string MiddleSentenceLength(string text)
        {
            char[] delimiterCharsSentences = { '.', '?', '!' };
            char[] delimiterCharsWords = { ' ', ',', '.', ':', '\t', '?', '!' };
            string[] sentences = text.Split(delimiterCharsSentences);
            var trimmedSentences = new List<string>();
            foreach (var s in sentences)
            {
                if (!s.Equals(""))
                {
                    trimmedSentences.Add(s.Trim(' '));
                }
            }
            double wordscount = 0;
            foreach (var s in trimmedSentences)
            {
                wordscount += Double.Parse(WordsCount(s));
            }
            double middle = wordscount / trimmedSentences.Count();
            middle = Math.Round(middle, 1);
            return middle.ToString();
        }
    }
}
