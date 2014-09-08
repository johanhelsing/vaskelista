namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskHouseholdId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tasks", name: "Household_HouseholdId", newName: "HouseholdId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Tasks", name: "HouseholdId", newName: "Household_HouseholdId");
        }
    }
}
