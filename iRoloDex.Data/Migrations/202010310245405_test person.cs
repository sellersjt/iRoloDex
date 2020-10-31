namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testperson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Household", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "Household_HouseholdId", "dbo.Household");
            DropIndex("dbo.Household", new[] { "Person_PersonId" });
            DropIndex("dbo.Person", new[] { "HouseholdId" });
            DropIndex("dbo.Person", new[] { "Household_HouseholdId" });
            DropColumn("dbo.Person", "HouseholdId");
            RenameColumn(table: "dbo.Person", name: "Household_HouseholdId", newName: "HouseholdId");
            AddColumn("dbo.Person", "Person_PersonId", c => c.Int());
            AlterColumn("dbo.Person", "HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "HouseholdId");
            CreateIndex("dbo.Person", "Person_PersonId");
            AddForeignKey("dbo.Person", "Person_PersonId", "dbo.Person", "PersonId");
            AddForeignKey("dbo.Person", "HouseholdId", "dbo.Household", "HouseholdId", cascadeDelete: true);
            DropColumn("dbo.Household", "Person_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Household", "Person_PersonId", c => c.Int());
            DropForeignKey("dbo.Person", "HouseholdId", "dbo.Household");
            DropForeignKey("dbo.Person", "Person_PersonId", "dbo.Person");
            DropIndex("dbo.Person", new[] { "Person_PersonId" });
            DropIndex("dbo.Person", new[] { "HouseholdId" });
            AlterColumn("dbo.Person", "HouseholdId", c => c.Int());
            DropColumn("dbo.Person", "Person_PersonId");
            RenameColumn(table: "dbo.Person", name: "HouseholdId", newName: "Household_HouseholdId");
            AddColumn("dbo.Person", "HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "Household_HouseholdId");
            CreateIndex("dbo.Person", "HouseholdId");
            CreateIndex("dbo.Household", "Person_PersonId");
            AddForeignKey("dbo.Person", "Household_HouseholdId", "dbo.Household", "HouseholdId");
            AddForeignKey("dbo.Household", "Person_PersonId", "dbo.Person", "PersonId");
        }
    }
}
