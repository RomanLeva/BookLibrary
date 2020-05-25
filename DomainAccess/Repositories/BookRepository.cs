using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Entities;
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

        public void Create(Book item)
        {
            if (item == null) return;

            if (item.Authors.FirstOrDefault().AuthorId != 0)
            {
                int id = item.Authors.FirstOrDefault().AuthorId;
                var author = _context.Authors.Where(a => a.AuthorId.Equals(id)).FirstOrDefault();
                if (author != null)
                {
                    item.Authors.Remove(item.Authors.FirstOrDefault());
                    item.Authors.Add(author);
                }
            }
            if (item.Genres.FirstOrDefault().GenreId != 0)
            {
                int id = item.Genres.FirstOrDefault().GenreId;
                var genre = _context.Genres.Where(a => a.GenreId.Equals(id)).FirstOrDefault();
                if (genre != null)
                {
                    item.Genres.Remove(item.Genres.FirstOrDefault());
                    item.Genres.Add(genre);
                }
            }
            _context.Books.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
        }

        public List<Book> Find(Func<Book, bool> predicate)
        {
            var set = _context.Books.Where(predicate).ToList();
            return set;
        }

        public Book Get(int id)
        {
            return _context.Books.Where(x => x.BookId == id).Include(b => b.Authors).Include(b => b.Genres).FirstOrDefault();
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Update(Book item)
        {
            var dbEntry = _context.Books.FirstOrDefault(x => x.BookId == item.BookId);
            if (dbEntry != null)
            {
                _context.Entry(dbEntry).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
        }
        public List<Book> Search(string BookName, string AuthorName, string Genre, string Date)
        {
            var books = new List<Book>();
            //if (!string.IsNullOrEmpty(BookName))
            //{
            //    books.AddRange(_context.Books.Where(book => book.Name.ToLower() == BookName.ToLower()).ToList());
            //}
            //if (!string.IsNullOrEmpty(AuthorName))
            //{
            //    books.AddRange(_context.Books.
            //        Where(b => b.Authors.Where(a => a.Name.ToLower().Equals(AuthorName.ToLower())).Count() > 0).ToList());
            //    if (books.Count > 0)
            //    {
            //        var list = books.Where(book => 
            //        book.Authors.Where(author => author.Name.ToLower().Equals(AuthorName.ToLower())).Count() > 0).ToList();
            //        books.Clear();
            //        books.AddRange(list);
            //    }

            //}
            //if (!string.IsNullOrEmpty(Genre))
            //{
            //    if (books.Count > 0)
            //    {
            //        var list = books.Where(book => 
            //        book.Genres.Where(genre => genre.Name.ToLower().Equals(Genre.ToLower())).Count() > 0).ToList();
            //        books.Clear();
            //        books.AddRange(list);
            //    }
            //    books.AddRange(_context.Books.
            //        Where(b => b.Genres.Where(g => g.Name.ToLower().Equals(Genre.ToLower())).Count() > 0).ToList());
            //}
            //if (!string.IsNullOrEmpty(Date))
            //{
            //    if (books.Count > 0)
            //    {
            //        var list = books.Where(book => book.PublicationDate.Year == int.Parse(Date)).ToList();
            //        books.Clear();
            //        books.AddRange(list);
            //    }
            //    books.AddRange(_context.Books.Where(b => b.PublicationDate.Year == int.Parse(Date)).ToList());
            //}

            bool byBook(Book book) => book.Name.ToLower() == BookName.ToLower();
            bool byAuthor(Book book) => book.Authors.Where(author => author.Name.ToLower().Equals(AuthorName.ToLower())).Count() > 0;
            bool byGenre(Book book) => book.Genres.Where(genre => genre.Name.ToLower().Equals(Genre.ToLower())).Count() > 0;
            bool byDate(Book book) => book.PublicationDate.Year == int.Parse(Date);
            string variant = "";
            if (BookName != "" & BookName != null)
            {
                variant += "B";
            }
            if (AuthorName != "" & AuthorName != null)
            {
                variant += "A";
            }
            if (Genre != "" & Genre != null)
            {
                variant += "G";
            }
            if (Date != "" & Date != null)
            {
                variant += "D";
            }
            switch (variant)
            {
                case "B":
                    {
                        books.AddRange(_context.Books.Where(byBook));
                        break;
                    }
                case "A":
                    {
                        books.AddRange(_context.Books.Where(byAuthor));
                        break;
                    }
                case "G":
                    {
                        books.AddRange(_context.Books.Where(byGenre));
                        break;
                    }
                case "D":
                    {
                        books.AddRange(_context.Books.Where(byDate));
                        break;
                    }
                case "BA":
                    {
                        books.AddRange(_context.Books.Where(byBook).Where(byAuthor));
                        break;
                    }
                case "BG":
                    {
                        books.AddRange(_context.Books.Where(byBook).Where(byGenre));
                        break;
                    }
                case "BD":
                    {
                        books.AddRange(_context.Books.Where(byBook).Where(byDate));
                        break;
                    }
                case "BAG":
                    {
                        books.AddRange(_context.Books.Where(byBook).Where(byAuthor).Where(byGenre));
                        break;
                    }
                case "BAD":
                    {
                        books.AddRange(_context.Books.Where(byBook).Where(byAuthor).Where(byDate));
                        break;
                    }
                case "BGD":
                    {
                        books.AddRange(_context.Books.Where(byBook).Where(byGenre).Where(byDate));
                        break;
                    }
                case "BAGD":
                    {
                        books.AddRange(_context.Books.Where(byBook).Where(byAuthor).Where(byGenre).Where(byDate));
                        break;
                    }
                case "AG":
                    {
                        books.AddRange(_context.Books.Where(byAuthor).Where(byGenre));
                        break;
                    }
                case "AD":
                    {
                        books.AddRange(_context.Books.Where(byAuthor).Where(byDate));
                        break;
                    }
                case "AGD":
                    {
                        books.AddRange(_context.Books.Where(byAuthor).Where(byGenre).Where(byDate));
                        break;
                    }
                case "GD":
                    {
                        books.AddRange(_context.Books.Where(byGenre).Where(byDate));
                        break;
                    }
                case "":
                    {
                        break;
                    }
            }
            return books;
        }
    }
}
