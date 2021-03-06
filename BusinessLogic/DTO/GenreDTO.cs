﻿using System.Collections.Generic;

namespace DataAccess.Dto
{
    public class GenreDto
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public virtual List<BookDto> Books { get; set; }
    }
}
