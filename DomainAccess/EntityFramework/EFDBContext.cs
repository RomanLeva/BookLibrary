using System.Configuration;
using System.Data.Entity;
using DataAccess.Repositories;

namespace DataAccess.EntityFramework
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(string connectionString) : base(connectionString)
        {
        }

        public EFDBContext()
        {
            Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["Book_Library"].ConnectionString;
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
