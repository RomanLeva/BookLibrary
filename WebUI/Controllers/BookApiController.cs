using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Mappings;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BookApiController : ApiController
    {
        // /api/bookapi/3232
        private readonly IMapper _mapper;
        private readonly IWebApiService _webService;

        public BookApiController(IWebApiService webService)
        {
            _webService = webService;
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<AutoMapperViewAndDtoProfile>();
                config.ForAllMaps((typeMap, mappingExpression) => mappingExpression.MaxDepth(1));
            });
            _mapper = new Mapper(mapperConfiguration);
        }
 
        [HttpGet]
        public List<BookDto> GetBooks()
        {
            return _webService.GetBooks();
        }

        [HttpGet]
        public BookViewModel GetBook(int id)
        {
            var dtoObj = _webService.GetBook(id);
            var viewObj = _mapper.Map<BookViewModel>(dtoObj);
            return viewObj;
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
        public void PostBook(BookDto book)
        {
            _webService.CreateOrUpdateBook(book);
        }
        [HttpDelete]
        public void DeleteBook(int id)
        {
            _webService.DeleteBook(id);
        }
    }
}