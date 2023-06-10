namespace LibApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookpublisher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PublisherID", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "PublisherID");
            AddForeignKey("dbo.Books", "PublisherID", "dbo.Publishers", "PublisherID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherID", "dbo.Publishers");
            DropIndex("dbo.Books", new[] { "PublisherID" });
            DropColumn("dbo.Books", "PublisherID");
        }
    }
}
