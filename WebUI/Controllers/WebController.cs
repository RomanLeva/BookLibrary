using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class WebController : ApiController
    {
        // /api/web/3232
        public IWebService WebService { get; set; }

        public WebController(IWebService webService)
        {
            WebService = webService;
        }
 
        [HttpGet]
        public List<BookDTO> GetBooks()
        {
            return WebService.GetBooks();
        }

        [HttpGet]
        public BookDTO GetBook(int id)
        {
            WebService.GetBook(id);
            var obj = WebService.GetBook(id);
            return obj;
            //if (obj == null)
            //{
            //    var message = string.Format("Product with id = {0} not found", id);
            //    HttpError err = new HttpError(message);
            //    return Request.CreateResponse(HttpStatusCode.NotFound, err);
            //}
            //else
            //{
            //    var bookJson = new BookJson();
            //    bookJson.BookId = obj.BookId.ToString();
            //    bookJson.Name = obj.Name;
            //    bookJson.Genre = obj.Genres.FirstOrDefault().Name;
            //    bookJson.Text = obj.Text;
            //    var list = new List<string>();
            //    foreach(var o in obj.Authors)
            //    {
            //        list.Add(o.Name+" "+o.Surname);
            //    }
            //    bookJson.Authors = list.ToArray();
            //    string output = JsonConvert.SerializeObject(bookJson);
            //    return obj;
            //}
        }
        [HttpPost]
        public void PostBook(BookDTO book)
        {
            WebService.CreateOrUpdateBook(book);
        }
        [HttpGet]
        public HttpResponseMessage GetAuthors()
        {
            var objs = WebService.GetAuthors();
            return null;
        }
        [HttpGet]
        public List<GenreDTO> GetGenres()
        {
            return WebService.GetGenres();
        }
    }
}