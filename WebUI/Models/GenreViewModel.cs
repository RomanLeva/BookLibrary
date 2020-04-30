using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class GenreViewModel
    {
        [Key]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Genre type is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public ICollection<BookViewModel> Books { get; set; }

        public GenreViewModel()
        {
            Books = new HashSet<BookViewModel>();
        }
    }
}