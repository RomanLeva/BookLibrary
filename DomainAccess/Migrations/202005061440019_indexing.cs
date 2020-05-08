namespace DomainAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indexing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Image", c => c.String());
            AlterColumn("dbo.Books", "Image", c => c.String());
            CreateIndex("dbo.Authors", "Name");
            CreateIndex("dbo.Authors", "Surname");
            CreateIndex("dbo.Books", "Name");
            CreateIndex("dbo.Genres", "Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Genres", new[] { "Name" });
            DropIndex("dbo.Books", new[] { "Name" });
            DropIndex("dbo.Authors", new[] { "Surname" });
            DropIndex("dbo.Authors", new[] { "Name" });
            AlterColumn("dbo.Books", "Image", c => c.Binary());
            AlterColumn("dbo.Authors", "Image", c => c.Binary());
        }
    }
}
