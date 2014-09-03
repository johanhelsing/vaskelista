namespace Vaskelista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskHouseholdRelation : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE dbo.Tasks");
            AddColumn("dbo.Tasks", "Household_HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "Household_HouseholdId");
            AddForeignKey("dbo.Tasks", "Household_HouseholdId", "dbo.Households", "HouseholdId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Household_HouseholdId", "dbo.Households");
            DropIndex("dbo.Tasks", new[] { "Household_HouseholdId" });
            DropColumn("dbo.Tasks", "Household_HouseholdId");
        }
    }
}
