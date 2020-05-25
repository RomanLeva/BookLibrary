using System.Collections.Generic;

namespace WebUI.Models
{
    public class PageViewModel
    {
        public List<BookViewModel> BookViewModels { get; set; }
        public List<AuthorViewModel> AuthorViewModels { get; set; }
        public List<GenreViewModel> GenreViewModels { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string PageStatistics { get; set; }
    }
}