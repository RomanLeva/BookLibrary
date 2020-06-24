using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();

        Author Get(int authorId);
    }
}
