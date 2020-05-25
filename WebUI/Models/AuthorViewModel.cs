using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class AuthorViewModel
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        public DateTime BirthDate { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<BookViewModel> Books { get; set; }
    }
}