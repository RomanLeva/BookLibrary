using Ninject.Modules;
using DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Repositories;
using AutoMapper;
using System.Configuration;

namespace BusinessLogic.Mappings
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Book_Library"].ConnectionString;
            Bind<EFDBContext>().To<EFDBContext>().WithConstructorArgument(connectionString);

            Bind<IBookRepository>().To<BookRepository>();
            Bind<IAuthorRepository>().To<AuthorRepository>();
            Bind<IGenreRepository>().To<GenreRepository>();
        }
    }
}
