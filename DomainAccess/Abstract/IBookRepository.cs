using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Abstract
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book Get(int id);
        List<Book> Find(Func<Book, Boolean> predicate);
        void Create(Book item);
        void Update(Book item);
        void Delete(int id);
        List<Book> Search(string BookName, string AuthorName, string Genre, string Date);
    }
}
