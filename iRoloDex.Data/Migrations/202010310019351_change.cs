namespace iRoloDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Household", "OwnerId", "dbo.Owner");
            DropIndex("dbo.Household", new[] { "OwnerId" });
            AlterColumn("dbo.Household", "OwnerId", c => c.Int());
            CreateIndex("dbo.Household", "OwnerId");
            AddForeignKey("dbo.Household", "OwnerId", "dbo.Owner", "OwnerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Household", "OwnerId", "dbo.Owner");
            DropIndex("dbo.Household", new[] { "OwnerId" });
            AlterColumn("dbo.Household", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Household", "OwnerId");
            AddForeignKey("dbo.Household", "OwnerId", "dbo.Owner", "OwnerId", cascadeDelete: true);
        }
    }
}
