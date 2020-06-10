using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebUI.Controllers
{
    public class BooksApiController : ApiController
    {
        // /api/bookapi/<bookId>
        private readonly IMapper _mapper;
        private readonly IWebApiService _webService;

        public BooksApiController(IWebApiService webService, IMapper mapper)
        {
            _webService = webService;
            _mapper = mapper;
        }
 
        [HttpGet]
        public List<BookDto> GetBooks()
        {
            return _webService.GetBooks();
        }

        [HttpGet]
        public BookDto GetBook(int bookId)
        {
            return _webService.GetBook(bookId);
        }

        [HttpPost]
        public void PostBook(BookDto bookDto)
        {
            _webService.CreateOrUpdateBook(bookDto);
        }

        [HttpDelete]
        public void DeleteBook(int bookId)
        {
            _webService.DeleteBook(bookId);
        }
    }
}