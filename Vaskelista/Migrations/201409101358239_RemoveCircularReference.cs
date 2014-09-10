namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCircularReference : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Activities", "ScheduleElementId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "ScheduleElementId", c => c.Int());
        }
    }
}
