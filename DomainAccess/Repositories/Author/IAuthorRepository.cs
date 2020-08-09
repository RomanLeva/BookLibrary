using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();

        Author Get(int authorId);
    }
}
