namespace Bugtracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        PositionID = c.Int(nullable: false),
                        Phone = c.String(),
                        Name = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        StatusID = c.Int(nullable: false),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.People", t => t.Person_PersonID)
                .Index(t => t.Person_PersonID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Person_PersonID", "dbo.People");
            DropIndex("dbo.Tickets", new[] { "Person_PersonID" });
            DropTable("dbo.Status");
            DropTable("dbo.Positions");
            DropTable("dbo.Tickets");
            DropTable("dbo.People");
        }
    }
}
