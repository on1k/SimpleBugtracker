namespace Bugtracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Person_PersonID", "dbo.People");
            DropIndex("dbo.Tickets", new[] { "Person_PersonID" });
            RenameColumn(table: "dbo.Tickets", name: "Person_PersonID", newName: "PersonID");
            AlterColumn("dbo.Tickets", "PersonID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "PersonID");
            AddForeignKey("dbo.Tickets", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "PersonID", "dbo.People");
            DropIndex("dbo.Tickets", new[] { "PersonID" });
            AlterColumn("dbo.Tickets", "PersonID", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "PersonID", newName: "Person_PersonID");
            CreateIndex("dbo.Tickets", "Person_PersonID");
            AddForeignKey("dbo.Tickets", "Person_PersonID", "dbo.People", "PersonID");
        }
    }
}
