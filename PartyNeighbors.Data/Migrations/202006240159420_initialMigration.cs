namespace PartyNeighbors.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Party", "Host_ResidentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Party", "Host_ResidentId");
            AddForeignKey("dbo.Party", "Host_ResidentId", "dbo.Resident", "ResidentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Party", "Host_ResidentId", "dbo.Resident");
            DropIndex("dbo.Party", new[] { "Host_ResidentId" });
            DropColumn("dbo.Party", "Host_ResidentId");
        }
    }
}
