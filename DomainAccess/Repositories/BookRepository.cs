using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DomainAccess.Abstract;
using DomainAccess.Entities;
using DomainAccess.EntityFramework;

namespace DomainAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private EFDBContext context;
        static BookRepository()
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

        public BookRepository(EFDBContext dbContext)
        {
            context = dbContext;
        }

        public void Create(Book item)
        {
            if (item == null) return;
            if (item.Authors.FirstOrDefault().AuthorId != 0)
            {
                //костыль? заменяю нового автора на уже сущ автора из базы (отслеживаемая сущьность), в итоге объект не дублируется в базе
                int id = item.Authors.FirstOrDefault().AuthorId; //сразу выражение для Ид нельзя подставить в Equals
                var author = context.Authors.Where(a => a.AuthorId.Equals(id)).FirstOrDefault();
                if (author != null)
                {
                    item.Authors.Remove(item.Authors.FirstOrDefault());
                    item.Authors.Add(author);
                }
            }
            if (item.Genres.FirstOrDefault().GenreId != 0)
            {
                //костыль? заменяю нового genre на уже сущ genre из базы (отслеживаемая сущьность), в итоге объект не дублируется в базе
                int id = item.Genres.FirstOrDefault().GenreId; //сразу выражение для Ид нельзя подставить в Equals
                var genre = context.Genres.Where(a => a.GenreId.Equals(id)).FirstOrDefault();
                if (genre != null)
                {
                    item.Genres.Remove(item.Genres.FirstOrDefault());
                    item.Genres.Add(genre);
                }
            }
            context.Books.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Books.Remove(context.Books.Find(id));
            context.SaveChanges();
        }

        public List<Book> Find(Func<Book, bool> predicate)
        {
            var set = context.Books.Where(predicate).ToList();
            return set;
        }

        public Book Get(int id)
        {
            return context.Books.Where(x => x.BookId == id).Include(b => b.Authors).Include(b => b.Genres).FirstOrDefault();
        }

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public void Update(Book item)
        {
            var dbEntry = context.Books.FirstOrDefault(x => x.BookId == item.BookId);
            if (dbEntry != null)
            {
                context.Entry(dbEntry).CurrentValues.SetValues(item); // НЕ МЕНЯЕТ АВТОРОВ!?
                context.SaveChanges();
            }
        }
        public List<Book> Search(string BookName, string AuthorName, string Genre, string Date)
        {
            Func<Book, bool> byB = b => b.Name.ToLower() == BookName.ToLower();
            Func<Book, bool> byA = b => b.Authors.Where(a => a.Name.ToLower().Equals(AuthorName.ToLower())).Count() > 0;
            Func<Book, bool> byG = b => b.Genres.Where(g => g.Name.ToLower().Equals(Genre.ToLower())).Count() > 0;
            Func<Book, bool> byD = b => b.Date.Year == int.Parse(Date);
            var books = new List<Book>();
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
                        books.AddRange(context.Books.Where(byB));
                        break;
                    }
                case "A":
                    {
                        books.AddRange(context.Books.Where(byA));
                        break;
                    }
                case "G":
                    {
                        books.AddRange(context.Books.Where(byG));
                        break;
                    }
                case "D":
                    {
                        books.AddRange(context.Books.Where(byD));
                        break;
                    }
                case "BA":
                    {
                        books.AddRange(context.Books.Where(byB).Where(byA));
                        break;
                    }
                case "BG":
                    {
                        books.AddRange(context.Books.Where(byB).Where(byG));
                        break;
                    }
                case "BD":
                    {
                        books.AddRange(context.Books.Where(byB).Where(byD));
                        break;
                    }
                case "BAG":
                    {
                        books.AddRange(context.Books.Where(byB).Where(byA).Where(byG));
                        break;
                    }
                case "BAD":
                    {
                        books.AddRange(context.Books.Where(byB).Where(byA).Where(byD));
                        break;
                    }
                case "BGD":
                    {
                        books.AddRange(context.Books.Where(byB).Where(byG).Where(byD));
                        break;
                    }
                case "BAGD":
                    {
                        books.AddRange(context.Books.Where(byB).Where(byA).Where(byG).Where(byD));
                        break;
                    }
                case "AG":
                    {
                        books.AddRange(context.Books.Where(byA).Where(byG));
                        break;
                    }
                case "AD":
                    {
                        books.AddRange(context.Books.Where(byA).Where(byD));
                        break;
                    }
                case "AGD":
                    {
                        books.AddRange(context.Books.Where(byA).Where(byG).Where(byD));
                        break;
                    }
                case "GD":
                    {
                        books.AddRange(context.Books.Where(byG).Where(byD));
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
