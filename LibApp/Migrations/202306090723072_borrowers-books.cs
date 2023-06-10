namespace LibApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowersbooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Borrowers",
                c => new
                    {
                        BorrowerID = c.Int(nullable: false, identity: true),
                        BorrowerFirstName = c.String(),
                        BorrowerLastName = c.String(),
                        BorrowerPhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowerID);
            
            CreateTable(
                "dbo.BorrowerBooks",
                c => new
                    {
                        Borrower_BorrowerID = c.Int(nullable: false),
                        Book_BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Borrower_BorrowerID, t.Book_BookID })
                .ForeignKey("dbo.Borrowers", t => t.Borrower_BorrowerID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookID, cascadeDelete: true)
                .Index(t => t.Borrower_BorrowerID)
                .Index(t => t.Book_BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowerBooks", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.BorrowerBooks", "Borrower_BorrowerID", "dbo.Borrowers");
            DropIndex("dbo.BorrowerBooks", new[] { "Book_BookID" });
            DropIndex("dbo.BorrowerBooks", new[] { "Borrower_BorrowerID" });
            DropTable("dbo.BorrowerBooks");
            DropTable("dbo.Borrowers");
        }
    }
}
