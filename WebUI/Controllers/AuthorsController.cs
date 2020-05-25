using System.Web.Mvc;
using BusinessLogic.Interfaces;
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

        // GET: Authors
        public ActionResult Authors()
        {
            var dtoObjs = _authorService.GetAll();
            var viewObjs = _mapper.Map<List<AuthorViewModel>>(dtoObjs);
            return View(viewObjs);
        }

        // GET: One author
        public ActionResult Author(int id)
        {
            var dtoObj = _authorService.GetById(id);
            var viewObj = _mapper.Map<AuthorViewModel>(dtoObj);
            return View(viewObj);
        }
    }
}