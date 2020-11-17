namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeviewertables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserHousehold", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUserHousehold", "Household_HouseholdId", "dbo.Household");
            DropForeignKey("dbo.PersonApplicationUser", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUserHousehold", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserHousehold", new[] { "Household_HouseholdId" });
            DropIndex("dbo.PersonApplicationUser", new[] { "Person_PersonId" });
            DropIndex("dbo.PersonApplicationUser", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserHousehold");
            DropTable("dbo.PersonApplicationUser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonApplicationUser",
                c => new
                    {
                        Person_PersonId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Person_PersonId, t.ApplicationUser_Id });
            
            CreateTable(
                "dbo.ApplicationUserHousehold",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Household_HouseholdId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Household_HouseholdId });
            
            CreateIndex("dbo.PersonApplicationUser", "ApplicationUser_Id");
            CreateIndex("dbo.PersonApplicationUser", "Person_PersonId");
            CreateIndex("dbo.ApplicationUserHousehold", "Household_HouseholdId");
            CreateIndex("dbo.ApplicationUserHousehold", "ApplicationUser_Id");
            AddForeignKey("dbo.PersonApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonApplicationUser", "Person_PersonId", "dbo.Person", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserHousehold", "Household_HouseholdId", "dbo.Household", "HouseholdId", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserHousehold", "ApplicationUser_Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}