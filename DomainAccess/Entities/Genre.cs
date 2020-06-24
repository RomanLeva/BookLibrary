using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Repositories
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
    }
}
