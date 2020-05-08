using System;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.Infrastructure;
using WebUI.Models;
using AutoMapper;
using System.Collections.Generic;
using BusinessLogic.DTO;
using WebUI.Infrastructure;
using System.Web;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;

namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;
        private IMapper mapper;

        public BooksController(IBookService bookService, IAuthorService authorService, IGenreService genreService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.genreService = genreService;
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<MyAutoMapperViewAndDto>();
            });
            mapper = new Mapper(mapperConfiguration);
        }
        // GET: Books
        public ActionResult Books()
        {
            var dtoObjs = bookService.GetAll();
            var viewObjs = mapper.Map<List<BookViewModel>>(dtoObjs);
            return View(viewObjs);
        }
        // GET: One book
        public ActionResult Book(int id)
        {
            var dtoObj = bookService.GetOne(id);
            var viewObj = mapper.Map<BookViewModel>(dtoObj);
            ViewBag.Stat = GetBookStatistics(viewObj);
            return View(viewObj);
        }
        [HttpPost]
        public ActionResult Edit(BookViewModel item, HttpPostedFileBase imageFile, HttpPostedFileBase textFile, string authorid, string genreid)
        {
            try
            {
                if (imageFile != null)
                {

                    var image = new byte[imageFile.ContentLength];
                    imageFile.InputStream.Read(image, 0, imageFile.ContentLength);
                    var path = Server.MapPath(@"/App_Data/images/" + item.Name + ".jpg");
                    System.IO.File.WriteAllBytes(path, image);
                    item.Image = "/App_Data/images/" + item.Name + ".jpg";
                    //using (var fileStream = System.IO.File.Create(HostingEnvironment.MapPath("/App_Data/images/" + item.Name + ".jpg")))
                    //{
                    //    fileStream.Write(image, 0, imageFile.ContentLength);
                    //}
                }
                if (textFile != null)
                {
                    item.Text = new StreamReader(textFile.InputStream).ReadToEnd();
                }
                var dtoObj = mapper.Map<BookDTO>(item);
                var authorDto = authorService.GetOne(int.Parse(authorid));
                dtoObj.Authors.Add(authorDto);
                var genreDto = genreService.GetOne(int.Parse(genreid));
                dtoObj.Genres.Add(genreDto);
                if (item.BookId == 0) // creating new book
                {
                    bookService.Create(dtoObj);
                }
                else // editing some book
                {
                    bookService.Update(dtoObj);
                }

                TempData["msg"] = string.Format("{0} has been saved", item.Name);
                return RedirectToAction("Books");
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                TempData["msg"] = e.Message;
                return RedirectToAction("Books");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dtoObj = bookService.GetOne(id);
            var viewObj = mapper.Map<BookViewModel>(dtoObj);
            var dtoObjsA = authorService.GetAll();
            var viewObjsA = mapper.Map<List<AuthorViewModel>>(dtoObjsA);
            ViewBag.Authors = viewObjsA;
            var dtoObjsG = genreService.GetAll();
            var viewObjsG = mapper.Map<List<GenreViewModel>>(dtoObjsG);
            ViewBag.Genres = viewObjsG;
            return View(viewObj);
        }
        public ActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Books");
        }
        public ActionResult Create()
        {
            var dtoObjsA = authorService.GetAll();
            var viewObjsA = mapper.Map<List<AuthorViewModel>>(dtoObjsA);
            ViewBag.Authors = viewObjsA;
            var dtoObjsG = genreService.GetAll();
            var viewObjsG = mapper.Map<List<GenreViewModel>>(dtoObjsG);
            ViewBag.Genres = viewObjsG;
            return View("Edit", new BookViewModel());
        }
        public ActionResult Search(string BookName, string AuthorName, string Genre, string Date)
        {
            var dtoObjs = bookService.Search(BookName, AuthorName, Genre, Date);
            var viewObjs = mapper.Map<List<BookViewModel>>(dtoObjs);
            return View("Books", viewObjs);
        }
        private string GetBookStatistics(BookViewModel book)
        {
            string text = book.Text;
            if (text == null || text == "") return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("Text length: ").Append(BookStatUtils.TextLength(text)).AppendLine();
            sb.Append("Words count: ").Append(BookStatUtils.WordsCount(text)).AppendLine();
            sb.Append("Unique words: ").Append(BookStatUtils.UniqueWordsCount(text)).AppendLine();
            sb.Append("Middle word length: ").Append(BookStatUtils.MiddleWordLegth(text)).AppendLine();
            sb.Append("Middle sentence length: ").Append(BookStatUtils.MiddleSentenceLength(text)).AppendLine();
            return sb.ToString();
        }

        public void Fill()
        {
            bookService.FillStorageWithFakeUsers();
        }
    }
}