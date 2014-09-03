namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomHouseholdRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "HouseHold_HouseholdId", "dbo.Households");
            DropIndex("dbo.Rooms", new[] { "HouseHold_HouseholdId" });
            AlterColumn("dbo.Rooms", "HouseHold_HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "HouseHold_HouseholdId");
            AddForeignKey("dbo.Rooms", "HouseHold_HouseholdId", "dbo.Households", "HouseholdId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "HouseHold_HouseholdId", "dbo.Households");
            DropIndex("dbo.Rooms", new[] { "HouseHold_HouseholdId" });
            AlterColumn("dbo.Rooms", "HouseHold_HouseholdId", c => c.Int());
            CreateIndex("dbo.Rooms", "HouseHold_HouseholdId");
            AddForeignKey("dbo.Rooms", "HouseHold_HouseholdId", "dbo.Households", "HouseholdId");
        }
    }
}
