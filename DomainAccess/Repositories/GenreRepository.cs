using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Entities;
using DataAccess.EntityFramework;

namespace DataAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly EFDBContext _context;
        static GenreRepository()
        {
            // the terrible hack, force downloading dll
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public GenreRepository(EFDBContext dbContext)
        {
            _context = dbContext;
        }

        public void Create(Genre item)
        {
            if (item == null) return;
            _context.Genres.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Genres.Remove(_context.Genres.Find(id));
            _context.SaveChanges();
        }

        public List<Genre> Find(Func<Genre, bool> predicate)
        {
            var set = _context.Genres.Where(predicate).ToList();
            return set;
        }

        public Genre Get(int genreId)
        {
            return _context.Genres.Where(x => x.GenreId == genreId).Include(b => b.Books).FirstOrDefault();
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public void Update(Genre item)
        {
            var dbEntry = _context.Genres.FirstOrDefault(x => x.GenreId == item.GenreId);
            if (dbEntry != null)
            {
                _context.Entry(dbEntry).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
        }
    }
}
