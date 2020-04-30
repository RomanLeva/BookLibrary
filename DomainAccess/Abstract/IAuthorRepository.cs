using DomainAccess.Entities;
using System;
using System.Collections.Generic;

namespace DomainAccess.Abstract
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
