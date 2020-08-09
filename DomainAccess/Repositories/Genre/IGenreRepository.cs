using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();

        Genre Get(int id);
    }
}
