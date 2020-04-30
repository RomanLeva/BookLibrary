using BusinessLogic.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IBookService
    {
        List<BookDTO> GetAll();
        BookDTO GetOne(int id);
        List<BookDTO> Find(Func<BookDTO, bool> predicate);
        void Create(BookDTO item);
        void Update(BookDTO item);
        void Delete(int id);
        List<BookDTO> Search(string BookName, string AuthorName, string Genre, string Date);
    }
}
