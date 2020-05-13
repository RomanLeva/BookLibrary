using System.Data.Entity;
using DomainAccess.Entities;
using DomainAccess.Migrations;

namespace DomainAccess.EntityFramework
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(string connectionString) : base(connectionString)
        {
        }
        public EFDBContext()
        {
        }
        public DbSet<Book> Books { get; set; } // Books and Authors are table names, <Book/Author> is entity.
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }

 }
