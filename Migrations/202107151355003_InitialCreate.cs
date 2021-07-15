namespace LibraryAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorID = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Author", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "AuthorID", "dbo.Author");
            DropIndex("dbo.Book", new[] { "AuthorID" });
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
