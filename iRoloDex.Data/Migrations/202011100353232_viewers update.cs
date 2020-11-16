namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewersupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonPerson", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonPerson", "Person_PersonId1", "dbo.Person");
            DropIndex("dbo.PersonPerson", new[] { "Person_PersonId" });
            DropIndex("dbo.PersonPerson", new[] { "Person_PersonId1" });
            CreateTable(
                "dbo.PersonApplicationUser",
                c => new
                    {
                        Person_PersonId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Person_PersonId, t.ApplicationUser_Id })
                .ForeignKey("dbo.Person", t => t.Person_PersonId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Person_PersonId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.HouseholdApplicationUser",
                c => new
                    {
                        Household_HouseholdId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Household_HouseholdId, t.ApplicationUser_Id })
                .ForeignKey("dbo.Household", t => t.Household_HouseholdId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Household_HouseholdId)
                .Index(t => t.ApplicationUser_Id);
            
            DropTable("dbo.PersonPerson");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonPerson",
                c => new
                    {
                        Person_PersonId = c.Int(nullable: false),
                        Person_PersonId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonId, t.Person_PersonId1 });
            
            DropForeignKey("dbo.HouseholdApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.HouseholdApplicationUser", "Household_HouseholdId", "dbo.Household");
            DropForeignKey("dbo.PersonApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PersonApplicationUser", "Person_PersonId", "dbo.Person");
            DropIndex("dbo.HouseholdApplicationUser", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.HouseholdApplicationUser", new[] { "Household_HouseholdId" });
            DropIndex("dbo.PersonApplicationUser", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PersonApplicationUser", new[] { "Person_PersonId" });
            DropTable("dbo.HouseholdApplicationUser");
            DropTable("dbo.PersonApplicationUser");
            CreateIndex("dbo.PersonPerson", "Person_PersonId1");
            CreateIndex("dbo.PersonPerson", "Person_PersonId");
            AddForeignKey("dbo.PersonPerson", "Person_PersonId1", "dbo.Person", "PersonId");
            AddForeignKey("dbo.PersonPerson", "Person_PersonId", "dbo.Person", "PersonId");
        }
    }
}
