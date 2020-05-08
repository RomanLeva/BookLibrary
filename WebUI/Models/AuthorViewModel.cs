using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class AuthorViewModel
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author surname is required.")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Author patronymic is required.")]
        [StringLength(50)]
        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public string Image { get; set; }

        [Required]
        public virtual ICollection<BookViewModel> AuthorsBooks { get; set; }

        public AuthorViewModel()
        {
            AuthorsBooks = new HashSet<BookViewModel>();
        }
    }
}