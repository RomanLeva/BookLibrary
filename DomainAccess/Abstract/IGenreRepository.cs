using DomainAccess.Entities;
using System;
using System.Collections.Generic;

namespace DomainAccess.Abstract
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();
        Genre Get(int id);
        List<Genre> Find(Func<Genre, Boolean> predicate);
        void Create(Genre item);
        void Update(Genre item);
        void Delete(int id);
    }
}
