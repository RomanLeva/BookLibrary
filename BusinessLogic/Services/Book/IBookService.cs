using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogic.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        BookDto GetById(int bookId);
        List<BookDto> Find(Func<BookDto, bool> predicate);
        void Create(BookDto item,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile);
        void Update(BookDto item,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile);
        void Delete(int id);
        List<BookDto> Search(string BookName, string AuthorName, string Genre, string Date);
        Task FillStorageWithFakeBooks();
    }
}
