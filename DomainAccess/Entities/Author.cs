using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Repositories
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [Index]
        [StringLength(50)]
        public string Name { get; set; }

        [Index]
        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        [Column(TypeName = "date")] //Used because of method Seed bug
        public DateTime BirthDate { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
