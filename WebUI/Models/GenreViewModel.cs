using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class GenreViewModel
    {
        [Key]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Genre type is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        public List<BookViewModel> Books { get; set; }
    }
}