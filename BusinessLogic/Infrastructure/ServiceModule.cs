using Ninject.Modules;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using System.Configuration;
using DomainAccess.Infrastructure;
using DataAccess.Infrastructore;

namespace DataAccess.Services
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Book_Library"].ConnectionString;
            Bind<EFDBContext>().To<EFDBContext>().WithConstructorArgument(connectionString);

            Bind<ConnectionConfiguration>().To<ConnectionConfiguration>();
            Bind<SqlBulkCopyFasade>().To<SqlBulkCopyFasade>();

            Bind<IBookRepository>().To<BookRepository>();
            Bind<IAuthorRepository>().To<AuthorRepository>();
            Bind<IGenreRepository>().To<GenreRepository>();
        }
    }
}
