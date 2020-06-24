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
                        Name = c.String(nullable: false),
                        PartyTime = c.DateTimeOffset(nullable: false, precision: 7),
                        HostId = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        NeighborhoodId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartyId)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId)
                .ForeignKey("dbo.Location", t => t.LocationId)
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
                        StateId = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.ResidentId)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId)
                .Index(t => t.NeighborhoodId);
            
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
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
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
                "dbo.NeighborhoodLocations",
                c => new
                    {
                        NeighborhoodId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NeighborhoodId, t.LocationId })
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.NeighborhoodId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.PartyItemResident",
                c => new
                    {
                        PartyItem_PartyItemId = c.Int(nullable: false),
                        Resident_ResidentId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PartyItem_PartyItemId, t.Resident_ResidentId })
                .ForeignKey("dbo.PartyItem", t => t.PartyItem_PartyItemId, cascadeDelete: true)
                .ForeignKey("dbo.Resident", t => t.Resident_ResidentId, cascadeDelete: true)
                .Index(t => t.PartyItem_PartyItemId)
                .Index(t => t.Resident_ResidentId);
            
            CreateTable(
                "dbo.PartyItemsList",
                c => new
                    {
                        PartyId = c.Int(nullable: false),
                        PartyItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartyId, t.PartyItemId })
                .ForeignKey("dbo.Party", t => t.PartyId, cascadeDelete: true)
                .ForeignKey("dbo.PartyItem", t => t.PartyItemId, cascadeDelete: true)
                .Index(t => t.PartyId)
                .Index(t => t.PartyItemId);
            
            CreateTable(
                "dbo.PartyResidents",
                c => new
                    {
                        PartyId = c.Int(nullable: false),
                        ResidentId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PartyId, t.ResidentId })
                .ForeignKey("dbo.Party", t => t.PartyId, cascadeDelete: true)
                .ForeignKey("dbo.Resident", t => t.ResidentId, cascadeDelete: true)
                .Index(t => t.PartyId)
                .Index(t => t.ResidentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Party", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.PartyResidents", "ResidentId", "dbo.Resident");
            DropForeignKey("dbo.PartyResidents", "PartyId", "dbo.Party");
            DropForeignKey("dbo.PartyItemsList", "PartyItemId", "dbo.PartyItem");
            DropForeignKey("dbo.PartyItemsList", "PartyId", "dbo.Party");
            DropForeignKey("dbo.Party", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Neighborhood", "StateId", "dbo.State");
            DropForeignKey("dbo.Resident", "NeighborhoodId", "dbo.Neighborhood");
            DropForeignKey("dbo.PartyItemResident", "Resident_ResidentId", "dbo.Resident");
            DropForeignKey("dbo.PartyItemResident", "PartyItem_PartyItemId", "dbo.PartyItem");
            DropForeignKey("dbo.Party", "NeighborhoodId", "dbo.Neighborhood");
            DropForeignKey("dbo.NeighborhoodLocations", "LocationId", "dbo.Location");
            DropForeignKey("dbo.NeighborhoodLocations", "NeighborhoodId", "dbo.Neighborhood");
            DropIndex("dbo.PartyResidents", new[] { "ResidentId" });
            DropIndex("dbo.PartyResidents", new[] { "PartyId" });
            DropIndex("dbo.PartyItemsList", new[] { "PartyItemId" });
            DropIndex("dbo.PartyItemsList", new[] { "PartyId" });
            DropIndex("dbo.PartyItemResident", new[] { "Resident_ResidentId" });
            DropIndex("dbo.PartyItemResident", new[] { "PartyItem_PartyItemId" });
            DropIndex("dbo.NeighborhoodLocations", new[] { "LocationId" });
            DropIndex("dbo.NeighborhoodLocations", new[] { "NeighborhoodId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Resident", new[] { "NeighborhoodId" });
            DropIndex("dbo.Neighborhood", new[] { "StateId" });
            DropIndex("dbo.Party", new[] { "LocationId" });
            DropIndex("dbo.Party", new[] { "NeighborhoodId" });
            DropIndex("dbo.Party", new[] { "CategoryId" });
            DropTable("dbo.PartyResidents");
            DropTable("dbo.PartyItemsList");
            DropTable("dbo.PartyItemResident");
            DropTable("dbo.NeighborhoodLocations");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.State");
            DropTable("dbo.PartyItem");
            DropTable("dbo.Resident");
            DropTable("dbo.Neighborhood");
            DropTable("dbo.Location");
            DropTable("dbo.Party");
            DropTable("dbo.Category");
        }
    }
}
