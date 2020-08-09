using System;
using System.Data.Entity.Migrations;
using DataAccess.Entities;
using DataAccess.EntityFramework;
using System.Collections.Generic;

namespace DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.EFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFDBContext efDbContext)
        {
            Author author = new Author();
            author.Books = new List<Book>();
            Book book = new Book();
            book.Authors = new List<Author>();
            book.Genres = new List<Genre>();
            author.Name = "Vasily";
            author.Patronymic = "Ivanovich";
            author.Surname = "Duborezov";
            author.BirthDate = DateTime.Parse("01/01/2016");
            author.ImageUrl = @"/images/default/author_image.jpg";
            book.Name = "Kolima-Magadan road";
            Genre genre = new Genre();
            genre.Books = new List<Book>();
            genre.Name = "History";
            book.Genres.Add(genre);
            genre.Books.Add(book);
            book.Isbn = "123456";
            book.Description = "Info about book";
            book.Text = "Some story about siberian Kamaz drivers living.";
            book.PublicationDate = DateTime.Parse("01/01/2018");
            book.ImageUrl = @"/images/default/book_image.jpg";
            book.Authors.Add(author);
            author.Books.Add(book);
            efDbContext.Books.Add(book);
            efDbContext.Authors.Add(author);
            efDbContext.Genres.Add(genre);

            Author author1 = new Author();
            author1.Books = new List<Book>();
            Book book1 = new Book();
            book1.Authors = new List<Author>();
            book1.Genres = new List<Genre>();
            author1.Name = "Petr";
            author1.Patronymic = "Vasilich";
            author1.Surname = "Ivanov";
            author1.BirthDate = DateTime.Parse("01/01/2015");
            author1.ImageUrl = @"/images/default/author_image.jpg";
            book1.Name = "Donbass ore mines";
            Genre genre1 = new Genre();
            genre1.Books = new List<Book>();
            genre1.Name = "Tech";
            genre1.Books.Add(book1);
            book1.Genres.Add(genre1);
            book1.Isbn = "864562";
            book1.Description = "Info about book";
            book1.Text = "some text about working underground.";
            book1.PublicationDate = DateTime.Parse("01/01/2019");
            book1.ImageUrl = @"/images/default/book_image.jpg";
            book1.Authors.Add(author1);
            author1.Books.Add(book1);
            efDbContext.Books.Add(book1);
            efDbContext.Authors.Add(author1);
            efDbContext.Genres.Add(genre1);

            Author author2 = new Author();
            author2.Books = new List<Book>();
            Book book2 = new Book();
            book2.Authors = new List<Author>();
            book2.Genres = new List<Genre>();
            author2.Name = "Ivan";
            author2.Patronymic = "Radionovich";
            author2.Surname = "Petrov";
            author2.BirthDate = DateTime.Parse("01/01/2017");
            author2.ImageUrl = @"/images/default/author_image.jpg";
            book2.Name = "Computer programming";
            Genre genre2 = new Genre();
            genre2.Books = new List<Book>();
            genre2.Name = "Science";
            genre2.Books.Add(book2);
            book2.Genres.Add(genre2);
            book2.Isbn = "596844";
            book2.Description = "Info about book";
            book2.Text = "How to programm computer.";
            book2.PublicationDate = DateTime.Parse("01/01/2020");
            book2.ImageUrl = @"/images/default/book_image.jpg";
            book2.Authors.Add(author2);
            author2.Books.Add(book2);
            efDbContext.Books.Add(book2);
            efDbContext.Authors.Add(author2);
            efDbContext.Genres.Add(genre2);

            efDbContext.SaveChanges();
        }
    }
}
