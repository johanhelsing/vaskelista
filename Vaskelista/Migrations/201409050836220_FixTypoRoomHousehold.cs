namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTypoRoomHousehold : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "HouseHold_HouseholdId", "dbo.Households");
            DropIndex("dbo.Rooms", new[] { "HouseHold_HouseholdId" });
            AlterColumn("dbo.Rooms", "Household_HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "Household_HouseholdId");
            AddForeignKey("dbo.Rooms", "Household_HouseholdId", "dbo.Households", "HouseholdId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Household_HouseholdId", "dbo.Households");
            DropIndex("dbo.Rooms", new[] { "Household_HouseholdId" });
            AlterColumn("dbo.Rooms", "Household_HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "HouseHold_HouseholdId");
            AddForeignKey("dbo.Rooms", "HouseHold_HouseholdId", "dbo.Households", "HouseholdId", cascadeDelete: true);
        }
    }
}
