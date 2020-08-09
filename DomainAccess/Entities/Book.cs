using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [Index]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")] //Using because of Seed method bug
        public DateTime PublicationDate { get; set; }

        [StringLength(100)]
        public string Isbn { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<BookTextStatistic> TextStatistics { get; set; }

        public virtual List<Author> Authors { get; set; }

        public virtual List<Genre> Genres { get; set; }
    }
}
