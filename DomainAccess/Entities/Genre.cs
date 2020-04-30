using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainAccess.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public virtual ICollection<Book> Books { get; set; }

        public Genre()
        {
            Books = new HashSet<Book>();
        }
    }
}
