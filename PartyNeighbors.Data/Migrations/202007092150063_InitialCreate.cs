namespace PartyNeighbors.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Party",
                c => new
                    {
                        PartyId = c.Int(nullable: false, identity: true),
                        PartyName = c.String(nullable: false),
                        PartyTime = c.DateTimeOffset(nullable: false, precision: 7),
                        HostId = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        NeighborhoodId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        ResidentId = c.Int(nullable: false),
                        ResidentName = c.String(),
                    })
                .PrimaryKey(t => t.PartyId)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.NeighborhoodId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Neighborhood",
                c => new
                    {
                        NeighborhoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        ResidentId = c.Int(nullable: false),
                        ResidentName = c.String(),
                        PartyId = c.Int(nullable: false),
                        PartyName = c.String(),
                        LocationId = c.Int(nullable: false),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.NeighborhoodId)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Resident",
                c => new
                    {
                        ResidentId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        NeighborhoodId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        PartyName = c.String(),
                    })
                .PrimaryKey(t => t.ResidentId)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId)
                .Index(t => t.NeighborhoodId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.PartyItem",
                c => new
                    {
                        PartyItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Purchased = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PartyItemId);
            
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
                "dbo.NeighborhoodLocation",
                c => new
                    {
                        Neighborhood_NeighborhoodId = c.Int(nullable: false),
                        Location_LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Neighborhood_NeighborhoodId, t.Location_LocationId })
                .ForeignKey("dbo.Neighborhood", t => t.Neighborhood_NeighborhoodId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.Location_LocationId, cascadeDelete: true)
                .Index(t => t.Neighborhood_NeighborhoodId)
                .Index(t => t.Location_LocationId);
            
            CreateTable(
                "dbo.ResidentParty",
                c => new
                    {
                        Resident_ResidentId = c.String(nullable: false, maxLength: 128),
                        Party_PartyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resident_ResidentId, t.Party_PartyId })
                .ForeignKey("dbo.Resident", t => t.Resident_ResidentId, cascadeDelete: true)
                .ForeignKey("dbo.Party", t => t.Party_PartyId, cascadeDelete: true)
                .Index(t => t.Resident_ResidentId)
                .Index(t => t.Party_PartyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Party", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Party", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Neighborhood", "StateId", "dbo.State");
            DropForeignKey("dbo.Resident", "NeighborhoodId", "dbo.Neighborhood");
            DropForeignKey("dbo.ResidentParty", "Party_PartyId", "dbo.Party");
            DropForeignKey("dbo.ResidentParty", "Resident_ResidentId", "dbo.Resident");
            DropForeignKey("dbo.Party", "NeighborhoodId", "dbo.Neighborhood");
            DropForeignKey("dbo.NeighborhoodLocation", "Location_LocationId", "dbo.Location");
            DropForeignKey("dbo.NeighborhoodLocation", "Neighborhood_NeighborhoodId", "dbo.Neighborhood");
            DropIndex("dbo.ResidentParty", new[] { "Party_PartyId" });
            DropIndex("dbo.ResidentParty", new[] { "Resident_ResidentId" });
            DropIndex("dbo.NeighborhoodLocation", new[] { "Location_LocationId" });
            DropIndex("dbo.NeighborhoodLocation", new[] { "Neighborhood_NeighborhoodId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Resident", new[] { "NeighborhoodId" });
            DropIndex("dbo.Neighborhood", new[] { "StateId" });
            DropIndex("dbo.Party", new[] { "LocationId" });
            DropIndex("dbo.Party", new[] { "NeighborhoodId" });
            DropIndex("dbo.Party", new[] { "CategoryId" });
            DropTable("dbo.ResidentParty");
            DropTable("dbo.NeighborhoodLocation");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PartyItem");
            DropTable("dbo.State");
            DropTable("dbo.Resident");
            DropTable("dbo.Neighborhood");
            DropTable("dbo.Location");
            DropTable("dbo.Party");
            DropTable("dbo.Category");
        }
    }
}
