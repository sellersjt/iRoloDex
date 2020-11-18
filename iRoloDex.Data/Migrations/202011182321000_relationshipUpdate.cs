namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Relationship", "RelationshipType", c => c.String(nullable: false));
            DropColumn("dbo.Relationship", "Name");
            DropColumn("dbo.Relationship", "CreatedUtc");
            DropColumn("dbo.Relationship", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Relationship", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Relationship", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Relationship", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Relationship", "RelationshipType", c => c.String());
        }
    }
}
