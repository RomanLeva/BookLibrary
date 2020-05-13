using Ninject.Modules;
using DomainAccess.EntityFramework;
using DomainAccess.Abstract;
using DomainAccess.Repositories;
using AutoMapper;
using System.Configuration;

namespace BusinessLogic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Book_Library"].ConnectionString;
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<MyAutoMapperEntityAndDto>();
            });
            Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
            Bind<IBookRepository>().To<BookRepository>().WithConstructorArgument("dbContext", new EFDBContext(connectionString));
            Bind<IAuthorRepository>().To<AuthorRepository>().WithConstructorArgument("dbContext", new EFDBContext(connectionString));
            Bind<IGenreRepository>().To<GenreRepository>().WithConstructorArgument("dbContext", new EFDBContext(connectionString));
        }
    }
}
