using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Infrastructure;
using AutoMapper;
using System.Web.Http;

namespace WebUI.Infrastructure
{
    public class MyNinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;
        public MyNinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            kernel.Load(new ServiceModule());
            kernel.Bind<IBookService>().To<BookService>();
            kernel.Bind<IAuthorService>().To<AuthorService>();
            kernel.Bind<IGenreService>().To<GenreService>();
            kernel.Bind<IWebService>().To<WebService>();
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<MyAutoMapperViewAndDto>();
            });
            
            //kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }
    }
}