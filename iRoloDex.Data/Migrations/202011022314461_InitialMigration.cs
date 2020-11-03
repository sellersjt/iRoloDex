namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Household",
                c => new
                    {
                        HouseholdId = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        OwnerId = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.HouseholdId)
                .ForeignKey("dbo.Owner", t => t.OwnerId)
                .ForeignKey("dbo.Person", t => t.Person_PersonId)
                .Index(t => t.OwnerId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Household_HouseholdId = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Household", t => t.Household_HouseholdId)
                .ForeignKey("dbo.Person", t => t.Person_PersonId)
                .Index(t => t.Household_HouseholdId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        HouseholdId = c.Int(nullable: false),
                        RelationshipId = c.Int(nullable: false),
                        Household_HouseholdId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Household", t => t.HouseholdId, cascadeDelete: true)
                .ForeignKey("dbo.Relationship", t => t.RelationshipId, cascadeDelete: true)
                .ForeignKey("dbo.Household", t => t.Household_HouseholdId)
                .Index(t => t.HouseholdId)
                .Index(t => t.RelationshipId)
                .Index(t => t.Household_HouseholdId);
            
            CreateTable(
                "dbo.Relationship",
                c => new
                    {
                        RelationshipId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RelationshipId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Person", "Household_HouseholdId", "dbo.Household");
            DropForeignKey("dbo.Person", "RelationshipId", "dbo.Relationship");
            DropForeignKey("dbo.ApplicationUser", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.Household", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "HouseholdId", "dbo.Household");
            DropForeignKey("dbo.Household", "OwnerId", "dbo.Owner");
            DropForeignKey("dbo.ApplicationUser", "Household_HouseholdId", "dbo.Household");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Person", new[] { "Household_HouseholdId" });
            DropIndex("dbo.Person", new[] { "RelationshipId" });
            DropIndex("dbo.Person", new[] { "HouseholdId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUser", new[] { "Person_PersonId" });
            DropIndex("dbo.ApplicationUser", new[] { "Household_HouseholdId" });
            DropIndex("dbo.Household", new[] { "Person_PersonId" });
            DropIndex("dbo.Household", new[] { "OwnerId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Relationship");
            DropTable("dbo.Person");
            DropTable("dbo.Owner");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Household");
        }
    }
}
