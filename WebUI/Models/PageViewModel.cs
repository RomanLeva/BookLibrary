using System.Collections.Generic;

namespace WebUI.Models
{
    public class PageViewModel
    {
        public static int leftBookId;
        public static int rightBookId;

        public List<BookViewModel> BookViewModels { get; set; }

        public List<AuthorViewModel> AuthorViewModels { get; set; }

        public List<GenreViewModel> GenreViewModels { get; set; }

        public BookTextStatisticViewModel BookTextStatistics { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}