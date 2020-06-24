using System.Web.Mvc;
using DataAccess.Services;
using WebUI.Models;
using AutoMapper;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public ActionResult Authors()
        {
            var authorsDto = _authorService.GetAll();
            var authorsView = _mapper.Map<List<AuthorViewModel>>(authorsDto);
            return View(authorsView);
        }

        public ActionResult Author(int authorId)
        {
            var authorDto = _authorService.GetById(authorId);
            var authorView = _mapper.Map<AuthorViewModel>(authorDto);
            return View(authorView);
        }
    }
}