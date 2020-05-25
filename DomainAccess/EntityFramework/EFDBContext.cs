using System.Configuration;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.EntityFramework
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(string connectionString) : base(connectionString)
        {
        }
        public EFDBContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Book_Library"].ConnectionString;
            Database.Connection.ConnectionString = connectionString;
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
    //PM> EntityFramework6\enable-migrations
    //PM> EntityFramework6\add-migration (than it will tell to specify name)
    //PM> EntityFramework6\update-database
}
