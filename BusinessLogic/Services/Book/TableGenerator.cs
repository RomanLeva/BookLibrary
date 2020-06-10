using System;
using System.Data;
using System.Text;

namespace BusinessLogic.Mappings
{
    public static class TableGenerator
    {
        private static readonly Random _Random = new Random();

        public static void FillStorageWithFakeBooks(int BooksIdCount, int AuthorsIdCount, int GenresIdCount )
        {
            var booksTable = CreateBooksTable(BooksIdCount);
            var authorsTable = CreateAuthorsTable(AuthorsIdCount);
            var genresTable = CreateGenresTable(GenresIdCount);
            var bookToAuthorstable = CreateBookAuthorsTable(BooksIdCount, GenresIdCount);
            var genreToBookstable = CreateGenreBooksTable(GenresIdCount, BooksIdCount);
            SqlBulkDataTableWriter.WriteDataTableToServer(booksTable);
            SqlBulkDataTableWriter.WriteDataTableToServer(authorsTable);
            SqlBulkDataTableWriter.WriteDataTableToServer(genresTable);
            SqlBulkDataTableWriter.WriteDataTableToServer(bookToAuthorstable);
            SqlBulkDataTableWriter.WriteDataTableToServer(genreToBookstable);
        }

        private static DataTable CreateBooksTable(int BooksIdCount)
        {
            var dataTable = new DataTable("Books");

            const string BookId = "BookId";
            const string Name = "Name";
            const string Description = "Description";
            const string PublicationDate = "PublicationDate";
            const string Isbn = "Isbn";
            const string Text = "Text";
            const string ImageUrl = "ImageUrl";

            var columns = new[] {BookId, Name, Description, PublicationDate, Isbn, Text, ImageUrl };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            for (var i = 1; i <= BooksIdCount; i++)
            {
                var row = dataTable.NewRow();
                row[Name] = GenerateName();
                row[Description] = _Random.Next(100000).ToString();
                row[PublicationDate] = new DateTime(2020, 1, 1); 
                row[Isbn] = _Random.Next(100000).ToString();
                row[Text] = "some random text" + _Random.Next(100000).ToString();
                row[ImageUrl] = "~\\images\\book_image.jpg";
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private static DataTable CreateAuthorsTable(int AuthorsIdCount)
        {
            var dataTable = new DataTable("Authors");

            const string AuthorId = "AuthorId";
            const string Name = "Name";
            const string Surname = "Surname";
            const string Patronymic = "Patronymic";
            const string BirthDate = "BirthDate";
            const string ImageUrl = "ImageUrl";

            var columns = new[] { AuthorId, Name, Surname, Patronymic, BirthDate, ImageUrl };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            for (var i = 1; i <= AuthorsIdCount; i++)
            {
                var row = dataTable.NewRow();
                row[Name] = GenerateName();
                row[Surname] = GenerateName();
                row[Patronymic] = GenerateName();
                row[BirthDate] = new DateTime(1987, 1, 1);
                row[ImageUrl] = "~\\images\\Kolima-Magadan road.jpg";
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private static DataTable CreateGenresTable(int GenresIdCount)
        {
            var dataTable = new DataTable("Genres");

            const string GenreId = "GenreId";
            const string Name = "Name";

            var columns = new[] { GenreId, Name };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            for (var i = 1; i <= GenresIdCount; i++)
            {
                var row = dataTable.NewRow();
                row[GenreId] = i;
                row[Name] = GenerateName();
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
        private static DataTable CreateBookAuthorsTable(int BooksIdCount, int AuthorsIdCount)
        {
            var dataTable = new DataTable("BookAuthors");

            const string Book_BookId = "Book_BookId";
            const string Author_AuthorId = "Author_AuthorId";

            var columns = new[] { Book_BookId, Author_AuthorId };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            var authorId = 1;
            for (var bookId = 1; bookId <= BooksIdCount; bookId++)
            {
                var row = dataTable.NewRow();
                row[Book_BookId] = bookId;
                row[Author_AuthorId] = ++authorId;
                dataTable.Rows.Add(row);
                if (authorId == AuthorsIdCount)
                {
                    authorId = 1;
                }
            }

            return dataTable;
        }

        private static DataTable CreateGenreBooksTable(int GenresIdCount, int BooksIdCount)
        {
            var dataTable = new DataTable("GenreBooks");

            const string Genre_GenreId = "Genre_GenreId";
            const string Book_BookId = "Book_BookId";

            var columns = new[] { Genre_GenreId, Book_BookId };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            var bookId = 1;
            for (var genreId = 1; genreId <= GenresIdCount; genreId++)
            {
                var row = dataTable.NewRow();
                row[Book_BookId] = bookId;
                row[Genre_GenreId] = ++bookId;
                dataTable.Rows.Add(row);
                if (bookId == BooksIdCount)
                {
                    bookId = 1;
                }
            }

            return dataTable;
        }

        private static string GenerateName()
        {
            var stringBuilder = new StringBuilder();

            var length = 7;
            char letter;

            for (int i = 0; i < length; i++)
            {
                var flt = _Random.NextDouble();
                var shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);

                stringBuilder.Append(letter);
            }

            return stringBuilder.ToString(); ;
        }
    }
}
