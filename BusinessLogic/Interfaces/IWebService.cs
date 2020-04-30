using BusinessLogic.DTO;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IWebService
    {
        List<BookDTO> GetBooks();
        BookDTO GetBook(int id);
        void CreateOrUpdateBook(BookDTO book);
        List<AuthorDTO> GetAuthors();
        List<GenreDTO> GetGenres();
        string GetBookStat(int id);
    }
}
