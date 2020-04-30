using System.Web.Mvc;
using BusinessLogic.Interfaces;
using WebUI.Models;
using AutoMapper;
using System.Collections.Generic;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService genreService;
        private IMapper mapper;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<MyAutoMapperViewAndDto>();
            });
            mapper = new Mapper(mapperConfiguration);
        }
        // GET: Genres
        public ActionResult Genres()
        {
            var dtoObjs = genreService.GetAll();
            var viewObjs = mapper.Map<List<GenreViewModel>>(dtoObjs);
            return View(viewObjs);
        }
        // GET: One genre
        public ActionResult Genre(int id)
        {
            var dtoObj = genreService.GetOne(id);
            var viewObj = mapper.Map<GenreViewModel>(dtoObj);
            return View(viewObj);
        }
    }
}