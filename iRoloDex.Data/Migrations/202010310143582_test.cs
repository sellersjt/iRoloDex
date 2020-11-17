namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "HouseholdId", "dbo.Household");
            AddColumn("dbo.Household", "Person_PersonId", c => c.Int());
            AddColumn("dbo.Person", "Household_HouseholdId", c => c.Int());
            CreateIndex("dbo.Household", "Person_PersonId");
            CreateIndex("dbo.Person", "Household_HouseholdId");
            AddForeignKey("dbo.Household", "Person_PersonId", "dbo.Person", "PersonId");
            AddForeignKey("dbo.Person", "Household_HouseholdId", "dbo.Household", "HouseholdId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "Household_HouseholdId", "dbo.Household");
            DropForeignKey("dbo.Household", "Person_PersonId", "dbo.Person");
            DropIndex("dbo.Person", new[] { "Household_HouseholdId" });
            DropIndex("dbo.Household", new[] { "Person_PersonId" });
            DropColumn("dbo.Person", "Household_HouseholdId");
            DropColumn("dbo.Household", "Person_PersonId");
            AddForeignKey("dbo.Person", "HouseholdId", "dbo.Household", "HouseholdId", cascadeDelete: true);
        }
    }
}