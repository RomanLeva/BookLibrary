using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DomainAccess.Abstract;
using DomainAccess.Entities;
using DomainAccess.EntityFramework;

namespace DomainAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private EFDBContext context;
        static AuthorRepository()
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

        public AuthorRepository(EFDBContext dbContext)
        {
            context = dbContext;
        }

        public void Create(Author item)
        {
            if (item == null) return;
            context.Authors.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Authors.Remove(context.Authors.Find(id));
            context.SaveChanges();
        }

        public List<Author> Find(Func<Author, bool> predicate)
        {
            var set = context.Authors.Where(predicate).ToList();
            return set;
        }

        public Author Get(int id)
        {
            return context.Authors.Where(x => x.AuthorId == id).Include(b => b.AuthorsBooks).FirstOrDefault();
        }

        public List<Author> GetAll()
        {
            return context.Authors.ToList();
        }

        public void Update(Author item)
        {
            var dbEntry = context.Authors.FirstOrDefault(x => x.AuthorId == item.AuthorId);
            if (dbEntry != null)
            {
                context.Entry(dbEntry).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}
