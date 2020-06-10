using System.Web.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappings;
using WebUI.Models;
using AutoMapper;
using System.Collections.Generic;
using BusinessLogic.Dto;
using System.Web;

namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        private readonly int _pagesize = 30;

        private readonly IMapper _mapper;
        
        public BooksController(IBookService bookService, IAuthorService authorService, IGenreService genreService, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
            _mapper = mapper;
        }

        public ActionResult Books(int page = 1)
        {
            var bookDto = _bookService.GetAll();

            var pageViewObj = new PageViewModel
            {
                BookViewModels = _mapper.Map<List<BookViewModel>>(bookDto),
                PageNumber = page,
                PageSize = _pagesize
            };

            return View(pageViewObj);
        }

        public ActionResult Book(int bookId)
        {
            var bookDto = _bookService.GetById(bookId);
            var bookView = _mapper.Map<BookViewModel>(bookDto);

            var pageViewObj = new PageViewModel
            {
                BookViewModels = new List<BookViewModel> { bookView },
                PageStatistics = TextStatisticsUtils.GetStatisticString(bookView.Text)
            };

            return View(pageViewObj);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel bookView,
            HttpPostedFileBase imageFile,
            HttpPostedFileBase textFile,
            string authorId, string genreId)
        {
            var bookDto = _mapper.Map<BookDto>(bookView);
            var authorDto = _authorService.GetById(int.Parse(authorId));
            bookDto.Authors.Add(authorDto);

            var genreDto = _genreService.GetById(int.Parse(genreId));
            bookDto.Genres.Add(genreDto);

            if (bookView.BookId == 0) // creating new book
            {
                _bookService.Create(bookDto, imageFile, textFile);
            }
            else // editing some book
            {
                _bookService.Update(bookDto, imageFile, textFile);
            }

            TempData["msg"] = string.Format("{0} has been saved", bookView.Name);

            return RedirectToAction("Books");
        }

        [HttpGet]
        public ActionResult Edit(int bookId)
        {
            var dtoBookObj = _bookService.GetById(bookId);
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

        public ActionResult Delete(int bookId)
        {
            _bookService.Delete(bookId);
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

        public ActionResult Fill()
        {
            TempData["msg"] = "Started creating alot of books in database";
            _bookService.FillStorageWithFakeBooks();
            
            return RedirectToAction("Books");
        }
    }
}