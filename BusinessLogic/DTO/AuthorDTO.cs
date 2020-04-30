using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte[] Image { get; set; }

        public ICollection<BookDTO> AuthorsBooks { get; set; }

        public AuthorDTO()
        {
            AuthorsBooks = new HashSet<BookDTO>();
        }
    }
}
