namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinishedTasks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        Finished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Tasks", new[] { "ActivityId" });
            DropTable("dbo.Tasks");
        }
    }
}
