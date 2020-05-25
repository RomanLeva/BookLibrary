using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Entities;
using DataAccess.EntityFramework;

namespace DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly EFDBContext _context;
        static AuthorRepository()
        {
            // the terrible hack, force downloading dll
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public AuthorRepository(EFDBContext dbContext)
        {
            _context = dbContext;
        }

        public void Create(Author item)
        {
            if (item == null) return;
            _context.Authors.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Authors.Remove(_context.Authors.Find(id));
            _context.SaveChanges();
        }

        public List<Author> Find(Func<Author, bool> predicate)
        {
            var set = _context.Authors.Where(predicate).ToList();
            return set;
        }

        public Author Get(int id)
        {
            return _context.Authors.Where(x => x.AuthorId == id).Include(b => b.Books).FirstOrDefault();
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public void Update(Author item)
        {
            var dbEntry = _context.Authors.FirstOrDefault(x => x.AuthorId == item.AuthorId);
            if (dbEntry != null)
            {
                _context.Entry(dbEntry).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
        }
    }
}
