using System.Collections.Generic;

namespace BusinessLogic.Dto
{
    public class GenreDto
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
