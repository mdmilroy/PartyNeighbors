namespace PartyNeighbors.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publishToAzure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartyRSVP",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PartyRSVP");
        }
    }
}
