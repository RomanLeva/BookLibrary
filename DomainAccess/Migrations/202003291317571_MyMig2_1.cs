namespace DomainAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMig2_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Text", c => c.Binary());
        }
    }
}
