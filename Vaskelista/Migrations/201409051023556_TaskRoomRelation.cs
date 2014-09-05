namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskRoomRelation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rooms", name: "Household_HouseholdId", newName: "HouseholdId");
            AddColumn("dbo.Tasks", "RoomId", c => c.Int());
            CreateIndex("dbo.Tasks", "RoomId");
            AddForeignKey("dbo.Tasks", "RoomId", "dbo.Rooms", "RoomId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Tasks", new[] { "RoomId" });
            DropColumn("dbo.Tasks", "RoomId");
            RenameColumn(table: "dbo.Rooms", name: "HouseholdId", newName: "Household_HouseholdId");
        }
    }
}
