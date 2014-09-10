namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateScheduleElementHousehold : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE dbo.ScheduleElements");
            DropForeignKey("dbo.ScheduleElements", "Household_HouseholdId", "dbo.Households");
            DropIndex("dbo.ScheduleElements", new[] { "Household_HouseholdId" });
            AlterColumn("dbo.ScheduleElements", "Household_HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.ScheduleElements", "Household_HouseholdId");
            AddForeignKey("dbo.ScheduleElements", "Household_HouseholdId", "dbo.Households", "HouseholdId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleElements", "Household_HouseholdId", "dbo.Households");
            DropIndex("dbo.ScheduleElements", new[] { "Household_HouseholdId" });
            AlterColumn("dbo.ScheduleElements", "Household_HouseholdId", c => c.Int());
            CreateIndex("dbo.ScheduleElements", "Household_HouseholdId");
            AddForeignKey("dbo.ScheduleElements", "Household_HouseholdId", "dbo.Households", "HouseholdId");
        }
    }
}
