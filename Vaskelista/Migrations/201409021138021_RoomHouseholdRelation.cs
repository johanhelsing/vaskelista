namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomHouseholdRelation : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE dbo.Rooms");
            AddColumn("dbo.Rooms", "HouseHold_HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "HouseHold_HouseholdId");
            AddForeignKey("dbo.Rooms", "HouseHold_HouseholdId", "dbo.Households", "HouseholdId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "HouseHold_HouseholdId", "dbo.Households");
            DropIndex("dbo.Rooms", new[] { "HouseHold_HouseholdId" });
            DropColumn("dbo.Rooms", "HouseHold_HouseholdId");
        }
    }
}
