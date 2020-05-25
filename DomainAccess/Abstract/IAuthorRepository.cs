using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Abstract
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author Get(int id);
        List<Author> Find(Func<Author, Boolean> predicate);
        void Create(Author item);
        void Update(Author item);
        void Delete(int id);
    }
}
