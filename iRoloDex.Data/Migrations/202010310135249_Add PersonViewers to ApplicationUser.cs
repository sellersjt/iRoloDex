namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonViewerstoApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUser", "Person_PersonId", "dbo.Person");
            DropIndex("dbo.ApplicationUser", new[] { "Person_PersonId" });
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
            
            DropColumn("dbo.ApplicationUser", "Person_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Person_PersonId", c => c.Int());
            DropForeignKey("dbo.PersonApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PersonApplicationUser", "Person_PersonId", "dbo.Person");
            DropIndex("dbo.PersonApplicationUser", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PersonApplicationUser", new[] { "Person_PersonId" });
            DropTable("dbo.PersonApplicationUser");
            CreateIndex("dbo.ApplicationUser", "Person_PersonId");
            AddForeignKey("dbo.ApplicationUser", "Person_PersonId", "dbo.Person", "PersonId");
        }
    }
}
