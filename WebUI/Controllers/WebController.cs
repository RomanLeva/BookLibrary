using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers
{
    public class WebController : ApiController
    {
        // /api/web/3232
        public IWebService WebService { get; set; }

        public WebController()
        {
            //WebService = webService;
        }
 
        [HttpGet]
        public List<BookDTO> GetBooks()
        {
            return WebService.GetBooks();
        }

        [HttpGet]
        public BookDTO GetBook(int id)
        {
            return WebService.GetBook(id);
        }
        [HttpPost]
        public void PostBook(BookDTO book)
        {
            WebService.CreateOrUpdateBook(book);
        }
        [HttpGet]
        public List<AuthorDTO> GetAuthors()
        {
            return WebService.GetAuthors();
        }
        [HttpGet]
        public List<GenreDTO> GetGenres()
        {
            return WebService.GetGenres();
        }
    }
}