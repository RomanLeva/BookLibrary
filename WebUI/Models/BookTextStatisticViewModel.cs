using System.Collections.Generic;

namespace WebUI.Models
{
    public class BookTextStatisticViewModel
    {
        public int BookTextId { get; set; }

        public int TextLength { get; set; }

        public int WordsCount { get; set; }

        public int UniqueWords { get; set; }

        public int AverageWordLenght { get; set; }

        public int AverageSentenceLenght { get; set; }

        public List<BookViewModel> Book { get; set; }
    }
}