namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameScheduleToHousehold : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Households",
                c => new
                    {
                        HouseholdId = c.Int(nullable: false, identity: true),
                        Token = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HouseholdId);
            
            DropTable("dbo.Schedules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            DropTable("dbo.Households");
        }
    }
}
