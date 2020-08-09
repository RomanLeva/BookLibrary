using DataAccess.Dto;
using DataAccess.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace WebUI.Controllers.Api
{
    //using adress as:  /api/booksapi/getbook/1
    public class BooksApiController : ApiController
    {
        private readonly IBookService _bookService;

        public BooksApiController(IBookService bookService)
        {
            _bookService = bookService;
        }
 
        [HttpGet]
        public List<BookDto> GetBooks()
        {
            return _bookService.GetAll();
        }

        [HttpGet]
        public BookDto GetBook(int bookId)
        {
            return _bookService.GetById(bookId);
        }

        [HttpPost]
        public void PostBook(BookDto bookDto)
        {
            //_bookService.Update(bookDto);
        }

        [HttpDelete]
        public void DeleteBook(int bookId)
        {
            _bookService.Delete(bookId);
        }
    }
}