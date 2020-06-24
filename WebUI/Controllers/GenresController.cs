using System.Web.Mvc;
using DataAccess.Services;
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

        public ActionResult Genres()
        {
            var genreDto = _genreService.GetAll();
            var genreView = _mapper.Map<List<GenreViewModel>>(genreDto);
            return View(genreView);
        }

        public ActionResult Genre(int genreId)
        {
            var genreDto = _genreService.GetById(genreId);
            var genreView = _mapper.Map<GenreViewModel>(genreDto);
            return View(genreView);
        }
    }
}