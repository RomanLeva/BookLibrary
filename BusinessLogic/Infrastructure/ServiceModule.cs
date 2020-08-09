using Ninject.Modules;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using DomainAccess.Infrastructure;
using DataAccess.Infrastructore;

namespace DataAccess.Services
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ConnectionConfiguration>().To<ConnectionConfiguration>();

            Bind<EFDBContext>().To<EFDBContext>();

            Bind<SqlBulkCopyFasade>().To<SqlBulkCopyFasade>();

            Bind<IBookRepository>().To<BookRepository>();
            Bind<IAuthorRepository>().To<AuthorRepository>();
            Bind<IGenreRepository>().To<GenreRepository>();
        }
    }
}
