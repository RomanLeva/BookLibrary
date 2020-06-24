using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();

        Book Get(int id);

        void Create(Book item);

        void Update(Book item);

        void Delete(int id);

        List<Book> Search(string bookName, string authorName, string genre, string date);
    }
}
