using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class BookViewModel
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
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

        [Required(ErrorMessage = "Author is required.")]
        public ICollection<AuthorViewModel> Authors { get; set; }

        [Required(ErrorMessage = "Genre type is required.")]
        public ICollection<GenreViewModel> Genres { get; set; }

        public BookViewModel()
        {
            Authors = new HashSet<AuthorViewModel>();
            Genres = new HashSet<GenreViewModel>();
        }
    }
}