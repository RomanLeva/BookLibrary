using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLogic.Infrastructure
{
    public static class TableGenerator
    {
        private static Random random = new Random();
        private static string connectionString;

        public static void FillStorageWithFakeUsers(string connectionString, int idBooksFrom, int idBooksTo, int idAuthorsFrom, int idAuthorsTo, int idGenresFrom, int idGenresTo)
        {
            TableGenerator.connectionString = connectionString;
            WriteToserver(CreateBooksTable(idBooksFrom, idBooksTo));
            WriteToserver(CreateAuthorsTable(idAuthorsFrom, idAuthorsTo));
            WriteToserver(CreateGenresTable(idGenresFrom, idGenresTo));
            WriteToserver(CreateBookAuthorsTable(idBooksFrom, idBooksTo, idAuthorsFrom, idAuthorsTo));
            WriteToserver(CreateGenreBooksTable(idGenresFrom, idGenresTo, idBooksFrom, idBooksTo));
        }
        private static void WriteToserver(DataTable table)
        {
            using (var sqlBulk = new SqlBulkCopy(connectionString))
            {
                sqlBulk.DestinationTableName = table.TableName;
                foreach (var column in table.Columns)
                {
                    sqlBulk.ColumnMappings.Add(column.ToString(), column.ToString());
                }
                try
                {
                    sqlBulk.WriteToServer(table);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
        }

        private static DataTable CreateBooksTable(int idFrom, int idTo)
        {
            var dataTable = new DataTable("Books");
            var columns = new[] { "BookId", "Name", "Description", "Date", "ISBN", "Text", "Image" };
            foreach (var column in columns)
            {
                var c = dataTable.Columns.Add(column);
                if (c.ColumnName.Equals("BookId"))
                {
                    c.AutoIncrement = true;
                    c.AutoIncrementSeed = idFrom;
                }
            }
            for (var i = idFrom; i <= idTo; i++)
            {
                var row = dataTable.NewRow();
                row["BookId"] = i;
                row["Name"] = GenerateName();
                row["Description"] = random.Next(100000).ToString();
                row["Date"] = new DateTime(2020, 1, 1); 
                row["ISBN"] = random.Next(100000).ToString();
                row["Text"] = "some random text" + random.Next(100000).ToString();
                row["Image"] = "~\\images\\book_image.jpg";
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private static DataTable CreateAuthorsTable(int idFrom, int idTo)
        {
            var dataTable = new DataTable("Authors");
            var columns = new[] { "AuthorId", "Name", "Surname", "Patronymic", "DateOfBirth", "Image" };
            foreach (var column in columns)
            {
                var c = dataTable.Columns.Add(column);
                if (c.ColumnName.Equals("AuthorId"))
                {
                    c.AutoIncrement = false;
                    c.AutoIncrementSeed = idFrom;
                }
            }
            for (var i = idFrom; i <= idTo; i++)
            {
                var row = dataTable.NewRow();
                row["AuthorId"] = i;
                row["Name"] = GenerateName();
                row["Surname"] = GenerateName();
                row["Patronymic"] = GenerateName();
                row["DateOfBirth"] = new DateTime(1987, 1, 1);
                row["Image"] = "~\\images\\Kolima-Magadan road.jpg";
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private static DataTable CreateGenresTable(int idFrom, int idTo)
        {
            var dataTable = new DataTable("Genres");
            var columns = new[] { "GenreId", "Name" };
            foreach (var column in columns)
            {
                var c = dataTable.Columns.Add(column);
                if (c.ColumnName.Equals("GenreId"))
                {
                    c.AutoIncrement = false;
                    c.AutoIncrementSeed = idFrom;
                }
                }
            for (var i = idFrom; i <= idTo; i++)
            {
                var row = dataTable.NewRow();
                row["GenreId"] = i;
                row["Name"] = GenerateName();
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        private static DataTable CreateBookAuthorsTable(int idBooksFrom, int idBooksTo, int idAuthorsFrom, int idAuthorsTo)
        {
            var dataTable = new DataTable("BookAuthors");
            var columns = new[] { "Book_BookId", "Author_AuthorId" };
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }
            var a = idAuthorsFrom;
            for (var b = idBooksFrom; b <= idBooksTo; b++)
            {
                var row = dataTable.NewRow();
                row["Book_BookId"] = b;
                row["Author_AuthorId"] = ++a;
                dataTable.Rows.Add(row);
                if (a == idAuthorsTo) a = idAuthorsFrom;
            }
            return dataTable;
        }

        private static DataTable CreateGenreBooksTable(int idGenresFrom, int idGenresTo, int idBooksFrom, int idBooksTo)
        {
            var dataTable = new DataTable("GenreBooks");
            var columns = new[] { "Genre_GenreId", "Book_BookId" };
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }
            var b = idBooksFrom;
            for (var g = idGenresFrom; g <= idGenresTo; g++)
            {
                var row = dataTable.NewRow();
                row["Book_BookId"] = b;
                row["Genre_GenreId"] = ++b;
                dataTable.Rows.Add(row);
                if (b == idBooksTo) b = idBooksFrom;
            }
            return dataTable;
        }

        private static string GenerateName()
        {
            int length = 7;
            StringBuilder str_build = new StringBuilder();
            char letter;
            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString(); ;
        }
    }
}
