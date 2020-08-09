using System.Data.Entity;
using DataAccess.Entities;
using DomainAccess.Infrastructure;

namespace DataAccess.EntityFramework
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(ConnectionConfiguration connection) : base(connection.ConnectionString)
        {
        }

        public EFDBContext()
        {
            Database.Connection.ConnectionString = new ConnectionConfiguration().ConnectionString;
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}

