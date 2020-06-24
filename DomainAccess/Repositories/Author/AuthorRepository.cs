using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public AuthorRepository(EFDBContext efDbContext)
        {
            _context = efDbContext;
        }

        public Author Get(int id)
        {
            return _context.Authors.Where(x => x.AuthorId == id).Include(b => b.Books).FirstOrDefault();
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }
    }
}
