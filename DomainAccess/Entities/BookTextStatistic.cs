using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class BookTextStatistic
    {
        [Key]
        public int BookTextId { get; set; }

        public string TextLength { get; set; }

        public string WordsCount { get; set; }

        public string UniqueWords { get; set; }

        public string AverageWordLenght { get; set; }

        public string AverageSentenceLenght { get; set; }

        public virtual List<Book> Book { get; set; }
    }
}
