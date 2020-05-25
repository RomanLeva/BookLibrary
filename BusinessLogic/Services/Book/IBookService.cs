using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        BookDto GetById(int bookId);
        List<BookDto> Find(Func<BookDto, bool> predicate);
        void Create(BookDto item);
        void Update(BookDto item);
        void Delete(int id);
        List<BookDto> Search(string BookName, string AuthorName, string Genre, string Date);
        Task FillStorageWithFakeUsers();
    }
}
