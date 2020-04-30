using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainAccess.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public virtual ICollection<Book> AuthorsBooks { get; set; }

        public Author()
        {
            AuthorsBooks = new HashSet<Book>();
        }

    }
}
