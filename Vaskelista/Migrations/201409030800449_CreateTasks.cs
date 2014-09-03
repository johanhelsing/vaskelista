namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTasks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
        }
    }
}
