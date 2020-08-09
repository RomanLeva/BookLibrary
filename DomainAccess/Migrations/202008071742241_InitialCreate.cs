namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Patronymic = c.String(maxLength: 50),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId)
                .Index(t => t.Name)
                .Index(t => t.Surname);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        PublicationDate = c.DateTime(nullable: false, storeType: "date"),
                        Isbn = c.String(maxLength: 100),
                        Text = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.BookId)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GenreId)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.BookTextStatistics",
                c => new
                    {
                        BookTextId = c.Int(nullable: false, identity: true),
                        TextLength = c.String(),
                        WordsCount = c.String(),
                        UniqueWords = c.String(),
                        AverageWordLenght = c.String(),
                        AverageSentenceLenght = c.String(),
                    })
                .PrimaryKey(t => t.BookTextId);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_BookId = c.Int(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_BookId, t.Author_AuthorId })
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .Index(t => t.Book_BookId)
                .Index(t => t.Author_AuthorId);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_GenreId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreId, t.Book_BookId })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Genre_GenreId)
                .Index(t => t.Book_BookId);
            
            CreateTable(
                "dbo.BookTextStatisticBooks",
                c => new
                    {
                        BookTextStatistic_BookTextId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookTextStatistic_BookTextId, t.Book_BookId })
                .ForeignKey("dbo.BookTextStatistics", t => t.BookTextStatistic_BookTextId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.BookTextStatistic_BookTextId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookTextStatisticBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.BookTextStatisticBooks", "BookTextStatistic_BookTextId", "dbo.BookTextStatistics");
            DropForeignKey("dbo.GenreBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books");
            DropIndex("dbo.BookTextStatisticBooks", new[] { "Book_BookId" });
            DropIndex("dbo.BookTextStatisticBooks", new[] { "BookTextStatistic_BookTextId" });
            DropIndex("dbo.GenreBooks", new[] { "Book_BookId" });
            DropIndex("dbo.GenreBooks", new[] { "Genre_GenreId" });
            DropIndex("dbo.BookAuthors", new[] { "Author_AuthorId" });
            DropIndex("dbo.BookAuthors", new[] { "Book_BookId" });
            DropIndex("dbo.Genres", new[] { "Name" });
            DropIndex("dbo.Books", new[] { "Name" });
            DropIndex("dbo.Authors", new[] { "Surname" });
            DropIndex("dbo.Authors", new[] { "Name" });
            DropTable("dbo.BookTextStatisticBooks");
            DropTable("dbo.GenreBooks");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.BookTextStatistics");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
