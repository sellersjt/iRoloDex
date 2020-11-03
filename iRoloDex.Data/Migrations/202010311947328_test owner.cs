namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testowner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Household", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "HouseholdId", "dbo.Household");
            DropForeignKey("dbo.Person", "OwnerId", "dbo.Owner");
            DropIndex("dbo.Household", new[] { "Person_PersonId" });
            DropIndex("dbo.Person", new[] { "HouseholdId" });
            DropIndex("dbo.Person", new[] { "OwnerId" });
            DropIndex("dbo.Person", new[] { "Household_HouseholdId" });
            DropColumn("dbo.Person", "HouseholdId");
            RenameColumn(table: "dbo.Person", name: "Household_HouseholdId", newName: "HouseholdId");
            AlterColumn("dbo.Person", "HouseholdId", c => c.Int());
            AlterColumn("dbo.Person", "OwnerId", c => c.Int());
            CreateIndex("dbo.Person", "HouseholdId");
            CreateIndex("dbo.Person", "OwnerId");
            AddForeignKey("dbo.Person", "HouseholdId", "dbo.Household", "HouseholdId");
            AddForeignKey("dbo.Person", "OwnerId", "dbo.Owner", "OwnerId");
            DropColumn("dbo.Household", "Person_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Household", "Person_PersonId", c => c.Int());
            DropForeignKey("dbo.Person", "OwnerId", "dbo.Owner");
            DropForeignKey("dbo.Person", "HouseholdId", "dbo.Household");
            DropIndex("dbo.Person", new[] { "OwnerId" });
            DropIndex("dbo.Person", new[] { "HouseholdId" });
            AlterColumn("dbo.Person", "OwnerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Person", "HouseholdId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Person", name: "HouseholdId", newName: "Household_HouseholdId");
            AddColumn("dbo.Person", "HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "Household_HouseholdId");
            CreateIndex("dbo.Person", "OwnerId");
            CreateIndex("dbo.Person", "HouseholdId");
            CreateIndex("dbo.Household", "Person_PersonId");
            AddForeignKey("dbo.Person", "OwnerId", "dbo.Owner", "OwnerId", cascadeDelete: true);
            AddForeignKey("dbo.Person", "HouseholdId", "dbo.Household", "HouseholdId", cascadeDelete: true);
            AddForeignKey("dbo.Household", "Person_PersonId", "dbo.Person", "PersonId");
        }
    }
}
