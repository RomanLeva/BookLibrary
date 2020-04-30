using System;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string ISBN { get; set; }

        public string Text { get; set; }

        public byte[] Image { get; set; }

        public ICollection<AuthorDTO> Authors { get; set; } // lazy loading

        public ICollection<GenreDTO> Genres { get; set; }

        public BookDTO()
        {
            Authors = new HashSet<AuthorDTO>();
            Genres = new HashSet<GenreDTO>();
        }
    }
}
