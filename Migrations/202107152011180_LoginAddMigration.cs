namespace LibraryAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginAddMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Login", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Login");
        }
    }
}
