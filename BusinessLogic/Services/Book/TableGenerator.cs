using System;
using System.Data;
using System.Text;

namespace DataAccess.Services
{
    public class TableGenerator
    {
        private readonly Random Random = new Random();
        private readonly int startingIndex = 1;

        public DataTable CreateBooksTable(int booksIdCount)
        {
            var dataTable = new DataTable("Books");

            const string bookId = "BookId";
            const string name = "Name";
            const string description = "Description";
            const string publicationDate = "PublicationDate";
            const string isbn = "Isbn";
            const string text = "Text";
            const string imageUrl = "ImageUrl";

            var columns = new[] {bookId, name, description, publicationDate, isbn, text, imageUrl };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            for (var i = startingIndex; i <= booksIdCount; i++)
            {
                var row = dataTable.NewRow();
                row[name] = GenerateName();
                row[description] = Random.Next(100000).ToString();
                row[publicationDate] = new DateTime(2020, 1, 1); 
                row[isbn] = Random.Next(100000).ToString();
                row[text] = "some random text" + Random.Next(100000).ToString();
                row[imageUrl] = "~\\images\\book_image.jpg";
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public DataTable CreateAuthorsTable(int authorsIdCount)
        {
            var dataTable = new DataTable("Authors");

            const string authorId = "AuthorId";
            const string name = "Name";
            const string surname = "Surname";
            const string patronymic = "Patronymic";
            const string birthDate = "BirthDate";
            const string imageUrl = "ImageUrl";

            var columns = new[] { authorId, name, surname, patronymic, birthDate, imageUrl };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            for (var i = startingIndex; i <= authorsIdCount; i++)
            {
                var row = dataTable.NewRow();
                row[name] = GenerateName();
                row[surname] = GenerateName();
                row[patronymic] = GenerateName();
                row[birthDate] = new DateTime(1987, 1, 1);
                row[imageUrl] = "~\\images\\Kolima-Magadan road.jpg";
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public DataTable CreateGenresTable(int genresIdCount)
        {
            var dataTable = new DataTable("Genres");

            const string genreId = "GenreId";
            const string name = "Name";

            var columns = new[] { genreId, name };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            for (var i = startingIndex; i <= genresIdCount; i++)
            {
                var row = dataTable.NewRow();
                row[genreId] = i;
                row[name] = GenerateName();
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public DataTable CreateBookAuthorsTable(int booksIdCount, int authorsIdCount)
        {
            var dataTable = new DataTable("BookAuthors");

            const string book_BookId = "Book_BookId";
            const string author_AuthorId = "Author_AuthorId";

            var columns = new[] { book_BookId, author_AuthorId };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            var authorId = startingIndex;
            for (var bookId = startingIndex; bookId <= booksIdCount; bookId++)
            {
                var row = dataTable.NewRow();
                row[book_BookId] = bookId;
                row[author_AuthorId] = ++authorId;
                dataTable.Rows.Add(row);
                if (authorId == authorsIdCount)
                {
                    authorId = 1;
                }
            }

            return dataTable;
        }

        public DataTable CreateGenreBooksTable(int genresIdCount, int booksIdCount)
        {
            var dataTable = new DataTable("GenreBooks");

            const string genre_GenreId = "Genre_GenreId";
            const string book_BookId = "Book_BookId";

            var columns = new[] { genre_GenreId, book_BookId };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            var bookId = startingIndex;
            for (var genreId = startingIndex; genreId <= genresIdCount; genreId++)
            {
                var row = dataTable.NewRow();
                row[book_BookId] = bookId;
                row[genre_GenreId] = ++bookId;
                dataTable.Rows.Add(row);
                if (bookId == booksIdCount)
                {
                    bookId = 1;
                }
            }

            return dataTable;
        }

        public string GenerateName()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var stringBuilder = new StringBuilder();
            const int nameLength = 7;

            for (int i = 0; i < nameLength; i++)
            {
                int num = random.Next(0, chars.Length - 1);
                var randomLetter = chars[num];
                stringBuilder.Append(randomLetter);
            }

            return stringBuilder.ToString();
        }
    }
}
