using System.Web.Mvc;
using BusinessLogic.Interfaces;
using WebUI.Models;
using AutoMapper;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }
        // GET: Genres
        public ActionResult Genres()
        {
            var dtoObjs = _genreService.GetAll();
            var viewObjs = _mapper.Map<List<GenreViewModel>>(dtoObjs);
            return View(viewObjs);
        }
        // GET: One genre
        public ActionResult Genre(int id)
        {
            var dtoObj = _genreService.GetById(id);
            var viewObj = _mapper.Map<GenreViewModel>(dtoObj);
            return View(viewObj);
        }
    }
}