using Ninject.Modules;
using DomainAccess.EntityFramework;
using DomainAccess.Abstract;
using DomainAccess.Repositories;
using AutoMapper;

namespace BusinessLogic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<MyAutoMapperEntityAndDto>();
            });
            Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
            Bind<IBookRepository>().To<BookRepository>().WithConstructorArgument("dbContext", new EFDBContext());
            Bind<IAuthorRepository>().To<AuthorRepository>().WithConstructorArgument("dbContext", new EFDBContext());
            Bind<IGenreRepository>().To<GenreRepository>().WithConstructorArgument("dbContext", new EFDBContext());
        }
    }
}
