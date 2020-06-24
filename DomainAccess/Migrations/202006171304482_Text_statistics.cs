namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Text_statistics : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.BookTextStatisticBooks", new[] { "Book_BookId" });
            DropIndex("dbo.BookTextStatisticBooks", new[] { "BookTextStatistic_BookTextId" });
            DropTable("dbo.BookTextStatisticBooks");
            DropTable("dbo.BookTextStatistics");
        }
    }
}
