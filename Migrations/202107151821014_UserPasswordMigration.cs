namespace LibraryAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPasswordMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Password", c => c.String(nullable: false));
            AddColumn("dbo.User", "PswdConfirmed", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "PswdConfirmed");
            DropColumn("dbo.User", "Password");
        }
    }
}
