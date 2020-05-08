using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainAccess.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [Index]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string ISBN { get; set; }

        public string Text { get; set; }

        public string Image { get; set; }

        [Required]
        public virtual ICollection<Author> Authors { get; set; }

        [Required]
        public virtual ICollection<Genre> Genres { get; set; }

        public Book()
        {
            Authors = new HashSet<Author>();
            Genres = new HashSet<Genre>();
        }
    }
}
