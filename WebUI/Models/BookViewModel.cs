using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class BookViewModel
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublicationDate { get; set; }

        [StringLength(100)]
        public string Isbn { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public List<AuthorViewModel> Authors { get; set; }

        public List<GenreViewModel> Genres { get; set; }
    }
}