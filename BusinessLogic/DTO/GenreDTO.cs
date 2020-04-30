using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class GenreDTO
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<BookDTO> Books { get; set; }

        public GenreDTO()
        {
            Books = new HashSet<BookDTO>();
        }
    }
}
