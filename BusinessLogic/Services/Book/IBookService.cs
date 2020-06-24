using DataAccess.Dto;
using System.Collections.Generic;
using System.Web;

namespace DataAccess.Services
{
    public interface IBookService
    {
        List<BookDto> GetAll();

        BookDto GetById(int bookId);

        void Create(
            BookDto item,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile);

        void Update(
            BookDto bookDto,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile);

        void Delete(int bookId);

        List<BookDto> Search(
            string bookName, 
            string authorName, 
            string genre, 
            string date);

        void FillStorageWithFakeBooks();
    }
}
