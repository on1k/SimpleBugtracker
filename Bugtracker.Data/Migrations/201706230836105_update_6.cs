namespace Bugtracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "PersonID", "dbo.People");
            DropIndex("dbo.Tickets", new[] { "PersonID" });
            RenameColumn(table: "dbo.Tickets", name: "PersonID", newName: "Person_PersonID");
            AddColumn("dbo.People", "FullName", c => c.String());
            AlterColumn("dbo.Tickets", "Person_PersonID", c => c.Int());
            CreateIndex("dbo.Tickets", "Person_PersonID");
            AddForeignKey("dbo.Tickets", "Person_PersonID", "dbo.People", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Person_PersonID", "dbo.People");
            DropIndex("dbo.Tickets", new[] { "Person_PersonID" });
            AlterColumn("dbo.Tickets", "Person_PersonID", c => c.Int(nullable: false));
            DropColumn("dbo.People", "FullName");
            RenameColumn(table: "dbo.Tickets", name: "Person_PersonID", newName: "PersonID");
            CreateIndex("dbo.Tickets", "PersonID");
            AddForeignKey("dbo.Tickets", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
        }
    }
}
