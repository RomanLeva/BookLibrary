using DomainAccess.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainAccess.Repositories;
using DomainAccess.EntityFramework;
using System;

namespace UnitTests
{
    [TestClass]
    public class MyDevelopingIntruments
    {
        //[TestMethod]
        public void CreateAuthors()
        {
            var repository = new AuthorRepository(new EFDBContext());

            Author author = new Author();
            author.Name = "Vasily";
            author.Patronymic = "Ivanovich";
            author.Surname = "Duborezov";
            author.DateOfBirth = DateTime.Parse("21/11/2017");
            repository.Create(author);

            Author author1 = new Author();
            author1.Name = "Petr";
            author1.Patronymic = "Vasilich";
            author1.Surname = "Ivanov";
            author1.DateOfBirth = DateTime.Parse("01/10/2015");
            repository.Create(author1);

            Author author2 = new Author();
            Book book2 = new Book();
            author2.Name = "Ivan";
            author2.Patronymic = "Radionovich";
            author2.Surname = "Petrov";
            author2.DateOfBirth = DateTime.Parse("01/9/2016");
            repository.Create(author2);
        }
        //[TestMethod]
        public void CreateFirstRowsInDB()
        {
            var repository = new BookRepository(new EFDBContext());

            Author author = new Author();
            Book book = new Book();
            author.Name = "Vasily";
            author.Patronymic = "Ivanovich";
            author.Surname = "Duborezov";
            author.DateOfBirth = DateTime.Parse("21/11/2017");
            book.Name = "Kolima-Magadan road";
            Genre genre = new Genre();
            genre.Name = "History";
            genre.Books.Add(book);
            book.Genres.Add(genre);
            book.ISBN = "123456";
            book.Description = "Info about book";
            book.Text = "Some story about siberian Kamaz drivers living.";
            book.Authors.Add(author);
            author.AuthorsBooks.Add(book);
            repository.Create(book);

            Author author1 = new Author();
            Book book1 = new Book();
            author1.Name = "Petr";
            author1.Patronymic = "Vasilich";
            author1.Surname = "Ivanov";
            author1.DateOfBirth = DateTime.Parse("01/10/2015");
            book1.Name = "Donbass ore mines";
            Genre genre1 = new Genre();
            genre1.Name = "Tech";
            genre1.Books.Add(book1);
            book1.Genres.Add(genre1);
            book1.ISBN = "864562";
            book1.Description = "Info about book";
            book1.Text = "some text about working underground.";
            book1.Authors.Add(author1);
            author1.AuthorsBooks.Add(book1);
            repository.Create(book1);

            Author author2 = new Author();
            Book book2 = new Book();
            author2.Name = "Ivan";
            author2.Patronymic = "Radionovich";
            author2.Surname = "Petrov";
            author2.DateOfBirth = DateTime.Parse("01/9/2016");
            book2.Name = "Computer programming";
            Genre genre2 = new Genre();
            genre2.Name = "Science";
            genre2.Books.Add(book2);
            book2.Genres.Add(genre2);
            book2.ISBN = "596844";
            book2.Description = "Info about book";
            book2.Text = "How to programm computer.";
            book2.Authors.Add(author2);
            author2.AuthorsBooks.Add(book2);
            repository.Create(book2);
        }
    }
}
