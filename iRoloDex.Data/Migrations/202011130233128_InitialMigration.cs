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
                    })
                .PrimaryKey(t => t.HouseholdId)
                .ForeignKey("dbo.Owner", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
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
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        OwnerId = c.Int(),
                        HouseholdId = c.Int(nullable: false),
                        RelationshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Household", t => t.HouseholdId, cascadeDelete: true)
                .ForeignKey("dbo.Owner", t => t.OwnerId)
                .ForeignKey("dbo.Relationship", t => t.RelationshipId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.HouseholdId)
                .Index(t => t.RelationshipId);
            
            CreateTable(
                "dbo.Relationship",
                c => new
                    {
                        RelationshipId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RelationshipType = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
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
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.PersonPerson",
                c => new
                    {
                        Person_PersonId = c.Int(nullable: false),
                        Person_PersonId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonId, t.Person_PersonId1 })
                .ForeignKey("dbo.Person", t => t.Person_PersonId)
                .ForeignKey("dbo.Person", t => t.Person_PersonId1)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Person_PersonId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Person", "RelationshipId", "dbo.Relationship");
            DropForeignKey("dbo.Person", "OwnerId", "dbo.Owner");
            DropForeignKey("dbo.PersonPerson", "Person_PersonId1", "dbo.Person");
            DropForeignKey("dbo.PersonPerson", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "HouseholdId", "dbo.Household");
            DropForeignKey("dbo.Household", "OwnerId", "dbo.Owner");
            DropIndex("dbo.PersonPerson", new[] { "Person_PersonId1" });
            DropIndex("dbo.PersonPerson", new[] { "Person_PersonId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Person", new[] { "RelationshipId" });
            DropIndex("dbo.Person", new[] { "HouseholdId" });
            DropIndex("dbo.Person", new[] { "OwnerId" });
            DropIndex("dbo.Household", new[] { "OwnerId" });
            DropTable("dbo.PersonPerson");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Relationship");
            DropTable("dbo.Person");
            DropTable("dbo.Owner");
            DropTable("dbo.Household");
        }
    }
}
