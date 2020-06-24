using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.EntityFramework;

namespace DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly EFDBContext _context;
        static BookRepository()
        {
            // the terrible hack, force downloading dll
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public BookRepository(EFDBContext dbContext)
        {
            _context = dbContext;
        }

        public void Create(Book book)
        {
            if (book == null)
            {
                return;
            }
            
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book Get(int bookId)
        {
            return _context.Books.Where(x => x.BookId == bookId).Include(b => b.Authors).Include(b => b.Genres).FirstOrDefault();
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Update(Book book)
        {
            var dbEntry = _context.Books.FirstOrDefault(x => x.BookId == book.BookId);
            if (dbEntry != null)
            {
                _context.Entry(dbEntry).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
        }
        public List<Book> Search(
            string bookName,
            string authorName,
            string genreName,
            string bookPublicationYear)
        {
            var booksQuery = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(bookName))
            {
                booksQuery = booksQuery.Where(book => book.Name.ToLower() == bookName.ToLower());
            }
            if (!string.IsNullOrEmpty(authorName))
            {
                booksQuery = booksQuery.Where(book => book.Authors.Where(author => author.Name.ToLower().Equals(authorName.ToLower())).Any());
            }
            if (!string.IsNullOrEmpty(genreName))
            {
                booksQuery = booksQuery.Where(book => book.Genres.Where(genre => genre.Name.ToLower().Equals(genreName.ToLower())).Any());
            }
            if (!string.IsNullOrEmpty(bookPublicationYear))
            {
                var pby = int.Parse(bookPublicationYear);
                booksQuery = booksQuery.Where(book => book.PublicationDate.Year == pby);
            }
            
            return booksQuery.ToList();
        }
    }
}
