namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorToScheduleElementAndActivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        HouseholdId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        RoomId = c.Int(),
                        ScheduleElementId = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.ScheduleElements",
                c => new
                    {
                        ScheduleElementId = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleElementId)
                .ForeignKey("dbo.Activities", t => t.ScheduleElementId)
                .Index(t => t.ScheduleElementId);
            
            DropTable("dbo.Tasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        HouseholdId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                        RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId);
            
            DropForeignKey("dbo.ScheduleElements", "ScheduleElementId", "dbo.Activities");
            DropIndex("dbo.ScheduleElements", new[] { "ScheduleElementId" });
            DropTable("dbo.ScheduleElements");
            DropTable("dbo.Activities");
        }
    }
}
