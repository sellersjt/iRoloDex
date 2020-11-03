namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergeupdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "HouseholdId", "dbo.Household");
            DropIndex("dbo.Person", new[] { "HouseholdId" });
            AddColumn("dbo.Relationship", "RelationshipType", c => c.String());
            AddColumn("dbo.Relationship", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Relationship", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Person", "HouseholdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "HouseholdId");
            AddForeignKey("dbo.Person", "HouseholdId", "dbo.Household", "HouseholdId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "HouseholdId", "dbo.Household");
            DropIndex("dbo.Person", new[] { "HouseholdId" });
            AlterColumn("dbo.Person", "HouseholdId", c => c.Int());
            DropColumn("dbo.Relationship", "ModifiedUtc");
            DropColumn("dbo.Relationship", "CreatedUtc");
            DropColumn("dbo.Relationship", "RelationshipType");
            CreateIndex("dbo.Person", "HouseholdId");
            AddForeignKey("dbo.Person", "HouseholdId", "dbo.Household", "HouseholdId");
        }
    }
}
