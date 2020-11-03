namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHouseholdViewerstoApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUser", "Household_HouseholdId", "dbo.Household");
            DropIndex("dbo.ApplicationUser", new[] { "Household_HouseholdId" });
            CreateTable(
                "dbo.ApplicationUserHousehold",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Household_HouseholdId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Household_HouseholdId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Household", t => t.Household_HouseholdId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Household_HouseholdId);
            
            DropColumn("dbo.ApplicationUser", "Household_HouseholdId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Household_HouseholdId", c => c.Int());
            DropForeignKey("dbo.ApplicationUserHousehold", "Household_HouseholdId", "dbo.Household");
            DropForeignKey("dbo.ApplicationUserHousehold", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUserHousehold", new[] { "Household_HouseholdId" });
            DropIndex("dbo.ApplicationUserHousehold", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserHousehold");
            CreateIndex("dbo.ApplicationUser", "Household_HouseholdId");
            AddForeignKey("dbo.ApplicationUser", "Household_HouseholdId", "dbo.Household", "HouseholdId");
        }
    }
}
