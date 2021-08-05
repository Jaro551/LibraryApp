namespace LibraryAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LibraryCard", "CreatedAt", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LibraryCard", "CreatedAt");
        }
    }
}
