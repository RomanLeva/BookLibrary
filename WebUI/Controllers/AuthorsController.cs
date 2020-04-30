using System.Web.Mvc;
using BusinessLogic.Interfaces;
using WebUI.Models;
using AutoMapper;
using System.Collections.Generic;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService authorService;
        private IMapper mapper;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<MyAutoMapperViewAndDto>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        // GET: Authors
        public ActionResult Authors()
        {
            var dtoObjs = authorService.GetAll();
            var viewObjs = mapper.Map<List<AuthorViewModel>>(dtoObjs);
            return View(viewObjs);
        }

        // GET: One author
        public ActionResult Author(int id)
        {
            var dtoObj = authorService.GetOne(id);
            var viewObj = mapper.Map<AuthorViewModel>(dtoObj);
            return View(viewObj);
        }
    }
}