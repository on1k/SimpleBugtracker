namespace Bugtracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.People", "PositionID");
            AddForeignKey("dbo.People", "PositionID", "dbo.Positions", "PositionID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PositionID", "dbo.Positions");
            DropIndex("dbo.People", new[] { "PositionID" });
        }
    }
}
