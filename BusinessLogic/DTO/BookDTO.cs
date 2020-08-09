using System;
using System.Collections.Generic;

namespace DataAccess.Dto
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Isbn { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<BookTextStatisticDto> TextStatistics { get; set; }

        public virtual List<AuthorDto> Authors { get; set; }

        public virtual List<GenreDto> Genres { get; set; }
    }
}
