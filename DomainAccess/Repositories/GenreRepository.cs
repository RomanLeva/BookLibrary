using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DomainAccess.Abstract;
using DomainAccess.Entities;
using DomainAccess.EntityFramework;

namespace DomainAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private EFDBContext context;
        static GenreRepository()
        {
            // the terrible hack, force downloading dll
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public bool TestConnection()
        {
            try
            {
                context.Database.Exists();
                context.Database.Connection.Open();
                context.Database.Connection.Close();
            }
            catch { return false; }
            return true;
        }

        public GenreRepository(EFDBContext dbContext)
        {
            context = dbContext;
        }

        public void Create(Genre item)
        {
            if (item == null) return;
            context.Genres.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Genres.Remove(context.Genres.Find(id));
            context.SaveChanges();
        }

        public List<Genre> Find(Func<Genre, bool> predicate)
        {
            var set = context.Genres.Where(predicate).ToList();
            return set;
        }

        public Genre Get(int id)
        {
            return context.Genres.Where(x => x.GenreId == id).Include(b => b.Books).FirstOrDefault();
        }

        public List<Genre> GetAll()
        {
            return context.Genres.ToList();
        }

        public void Update(Genre item)
        {
            var dbEntry = context.Genres.FirstOrDefault(x => x.GenreId == item.GenreId);
            if (dbEntry != null)
            {
                context.Entry(dbEntry).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}
