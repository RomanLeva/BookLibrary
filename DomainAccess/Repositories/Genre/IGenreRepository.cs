using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();

        Genre Get(int id);
    }
}
