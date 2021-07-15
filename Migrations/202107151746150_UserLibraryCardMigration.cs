namespace LibraryAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLibraryCardMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LibraryCard",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.Book", "LibraryCardID", c => c.Int());
            AddColumn("dbo.Book", "LibraryCard_UserID", c => c.Int());
            AlterColumn("dbo.Author", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Author", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Book", "Title", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Book", "LibraryCard_UserID");
            AddForeignKey("dbo.Book", "LibraryCard_UserID", "dbo.LibraryCard", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibraryCard", "UserID", "dbo.User");
            DropForeignKey("dbo.Book", "LibraryCard_UserID", "dbo.LibraryCard");
            DropIndex("dbo.LibraryCard", new[] { "UserID" });
            DropIndex("dbo.Book", new[] { "LibraryCard_UserID" });
            AlterColumn("dbo.Book", "Title", c => c.String());
            AlterColumn("dbo.Author", "LastName", c => c.String());
            AlterColumn("dbo.Author", "FirstName", c => c.String());
            DropColumn("dbo.Book", "LibraryCard_UserID");
            DropColumn("dbo.Book", "LibraryCardID");
            DropTable("dbo.User");
            DropTable("dbo.LibraryCard");
        }
    }
}
