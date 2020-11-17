namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addicollectionstoperson : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.PersonPerson", "Person_PersonId1", "dbo.Person");
            DropForeignKey("dbo.PersonPerson", "Person_PersonId", "dbo.Person");
            DropIndex("dbo.PersonPerson", new[] { "Person_PersonId1" });
            DropIndex("dbo.PersonPerson", new[] { "Person_PersonId" });
            DropTable("dbo.PersonPerson");
        }
    }
}