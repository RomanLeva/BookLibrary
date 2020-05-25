using System;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappings;
using WebUI.Models;
using AutoMapper;
using System.Collections.Generic;
using BusinessLogic.DTO;
using System.Web;
using System.IO;
using Castle.Core.Internal;

namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly int _pagesize = 30;

        public BooksController(IBookService bookService, IAuthorService authorService, IGenreService genreService, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
            _mapper = mapper;
        }
        // GET: Books
        public ActionResult Books(int? id)
        {
            var pageNumber = id ?? 1;

            var dtoObjs = _bookService.GetAll();

            var pageViewObj = new PageViewModel
            {
                BookViewModels = _mapper.Map<List<BookViewModel>>(dtoObjs),
                PageNumber = pageNumber,
                PageSize = _pagesize
            };

            return View(pageViewObj);
        }
        // GET: One book
        public ActionResult Book(int id)
        {
            var dtoObj = _bookService.GetById(id);
            var viewObj = _mapper.Map<BookViewModel>(dtoObj);

            var pageViewObj = new PageViewModel
            {
                BookViewModels = new List<BookViewModel> { viewObj },
                PageStatistics = GetBookStatistics(viewObj)
            };

            return View(pageViewObj);
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

                    var path = Server.MapPath(@"/images/books/" + item.Name + ".jpg");
                    System.IO.File.WriteAllBytes(path, image);

                    item.ImageUrl = "/images/books/" + item.Name + ".jpg";
                }
                if (textFile != null)
                {
                    item.Text = new StreamReader(textFile.InputStream).ReadToEnd();
                }

                var dtoObj = _mapper.Map<BookDto>(item);
                var authorDto = _authorService.GetById(int.Parse(authorid));
                dtoObj.Authors.Add(authorDto);

                var genreDto = _genreService.GetById(int.Parse(genreid));
                dtoObj.Genres.Add(genreDto);

                if (item.BookId == 0) // creating new book
                {
                    _bookService.Create(dtoObj);
                }
                else // editing some book
                {
                    _bookService.Update(dtoObj);
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
            var dtoBookObj = _bookService.GetById(id);
            var viewBookObj = _mapper.Map<BookViewModel>(dtoBookObj);

            var dtoAuthorObjs = _authorService.GetAll();
            var viewAuthorObjs = _mapper.Map<List<AuthorViewModel>>(dtoAuthorObjs);
            var dtoGenreObjs = _genreService.GetAll();
            var viewGenreObjs = _mapper.Map<List<GenreViewModel>>(dtoGenreObjs);

            var pageViewObj = new PageViewModel
            {
                BookViewModels = new List<BookViewModel> { viewBookObj },
                AuthorViewModels = viewAuthorObjs,
                GenreViewModels = viewGenreObjs
            };

            return View(pageViewObj);
        }
        public ActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Books");
        }
        public ActionResult Create()
        {
            var dtoAuthorObjs = _authorService.GetAll();
            var viewAuthorObjs = _mapper.Map<List<AuthorViewModel>>(dtoAuthorObjs);
            var dtoGenreObjs = _genreService.GetAll();
            var viewGenreObjs = _mapper.Map<List<GenreViewModel>>(dtoGenreObjs);

            var pageViewObj = new PageViewModel
            {
                BookViewModels = new List<BookViewModel> { new BookViewModel() },
                AuthorViewModels = viewAuthorObjs,
                GenreViewModels = viewGenreObjs
            };

            return View("Edit", pageViewObj);
        }
        public ActionResult Search(string BookName, string AuthorName, string Genre, string Date)
        {
            var dtoObjs = _bookService.Search(BookName, AuthorName, Genre, Date);

            var pageViewObj = new PageViewModel
            {
                BookViewModels = _mapper.Map<List<BookViewModel>>(dtoObjs),
                PageNumber = 1,
                PageSize = _pagesize
            };

            return View("Books", pageViewObj);
        }
        private string GetBookStatistics(BookViewModel book)
        {
            string text = book.Text;
            if (text.IsNullOrEmpty())
            {
                return "";
            }
            return TextStatisticsUtils.GetStatisticString(text);
            
        }

        public ActionResult Fill()
        {
            _bookService.FillStorageWithFakeUsers();
            TempData["msg"] = "Started creating alot of books in database";
            return RedirectToAction("Books");
        }
    }
}