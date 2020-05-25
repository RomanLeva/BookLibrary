using System;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime BirthDate { get; set; }

        public string ImageUrl { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
