using BusinessLogic.DTO;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IWebApiService
    {
        List<BookDto> GetBooks();
        BookDto GetBook(int id);
        void CreateOrUpdateBook(BookDto book);
        void DeleteBook(int id);
        string GetBookStatistics(int id);
    }
}
