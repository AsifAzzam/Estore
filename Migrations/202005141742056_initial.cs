namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cosmatics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        price = c.Int(nullable: false),
                        Category = c.String(),
                        Available = c.Boolean(nullable: false),
                        Manufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.Manufacturer_Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactNo = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeAppliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.Byte(nullable: false),
                        Display = c.String(),
                        Name = c.String(),
                        price = c.Int(nullable: false),
                        Category = c.String(),
                        Available = c.Boolean(nullable: false),
                        Manufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.Manufacturer_Id);
            
            CreateTable(
                "dbo.MenClothings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MobilePhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScreenSize = c.String(),
                        FrontCamera = c.Byte(nullable: false),
                        RearCamera = c.Byte(nullable: false),
                        Display = c.String(),
                        Name = c.String(),
                        price = c.Int(nullable: false),
                        Category = c.String(),
                        Available = c.Boolean(nullable: false),
                        Manufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.Manufacturer_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WomenClothings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Size = c.String(),
                        Name = c.String(),
                        price = c.Int(nullable: false),
                        Category = c.String(),
                        Available = c.Boolean(nullable: false),
                        Manufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.Manufacturer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WomenClothings", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MobilePhones", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.HomeAppliances", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.Cosmatics", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.WomenClothings", new[] { "Manufacturer_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.MobilePhones", new[] { "Manufacturer_Id" });
            DropIndex("dbo.HomeAppliances", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Cosmatics", new[] { "Manufacturer_Id" });
            DropTable("dbo.WomenClothings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MobilePhones");
            DropTable("dbo.MenClothings");
            DropTable("dbo.HomeAppliances");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Cosmatics");
        }
    }
}
