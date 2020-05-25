using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [Index]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
