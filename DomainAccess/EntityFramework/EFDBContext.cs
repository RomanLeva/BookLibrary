using System.Data.Entity;
using DomainAccess.Entities;

namespace DomainAccess.EntityFramework
{
    public class EFDBContext : DbContext
    {
        public EFDBContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pcv\\Documents\\BookLibrary.mdf;Integrated Security=True;Connect Timeout=30")
        {
        }
        
        public DbSet<Book> Books { get; set; } // Books and Authors are table names, <Book/Author> is entity.
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }

 }
