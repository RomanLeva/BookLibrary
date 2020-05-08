namespace DomainAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using DomainAccess.Entities;
    using DomainAccess.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<DomainAccess.EntityFramework.EFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //PM> EntityFramework6\enable-migrations
        //PM> EntityFramework6\add-migration (than it will tell to specify name)
        //PM> EntityFramework6\update-database

        protected override void Seed(EFDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            Author author = new Author();
            Book book = new Book();
            author.Name = "Vasily";
            author.Patronymic = "Ivanovich";
            author.Surname = "Duborezov";
            author.DateOfBirth = System.DateTime.Now;
            book.Name = "Kolima-Magadan road";
            Genre genre = new Genre();
            genre.Name = "History";
            genre.Books.Add(book);
            book.Genres.Add(genre);
            book.ISBN = "123456";
            book.Description = "Info about book";
            book.Text = "Some story about siberian Kamaz drivers living.";
            
            //book.Image = File.ReadAllBytes(@"..\Image\test_pict.jpg");
            book.Authors.Add(author);
            author.AuthorsBooks.Add(book);
            context.Authors.Add(author);
            context.Books.Add(book);
          
            context.SaveChanges();
        }
    }
}
