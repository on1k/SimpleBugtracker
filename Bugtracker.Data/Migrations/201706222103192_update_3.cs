namespace Bugtracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tickets", "StatusID");
            AddForeignKey("dbo.Tickets", "StatusID", "dbo.Status", "StatusID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "StatusID", "dbo.Status");
            DropIndex("dbo.Tickets", new[] { "StatusID" });
        }
    }
}
