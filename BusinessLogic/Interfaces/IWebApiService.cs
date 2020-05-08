using BusinessLogic.DTO;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IWebApiService
    {
        List<BookDTO> GetBooks();
        BookDTO GetBook(int id);
        void CreateOrUpdateBook(BookDTO book);
        void DeleteBook(int id);
        string GetBookStat(int id);
        List<AuthorDTO> GetAuthors();
        List<GenreDTO> GetGenres();
    }
}
