namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attrtomanuf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cosmatics", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.HomeAppliances", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.MenClothings", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.MobilePhones", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.WomenClothings", "Stock", c => c.Int(nullable: false));
            AlterColumn("dbo.Cosmatics", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cosmatics", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.HomeAppliances", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.HomeAppliances", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.MenClothings", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MenClothings", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.MobilePhones", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MobilePhones", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.WomenClothings", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.WomenClothings", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WomenClothings", "Category", c => c.String());
            AlterColumn("dbo.WomenClothings", "Name", c => c.String());
            AlterColumn("dbo.MobilePhones", "Category", c => c.String());
            AlterColumn("dbo.MobilePhones", "Name", c => c.String());
            AlterColumn("dbo.MenClothings", "Category", c => c.String());
            AlterColumn("dbo.MenClothings", "Name", c => c.String());
            AlterColumn("dbo.HomeAppliances", "Category", c => c.String());
            AlterColumn("dbo.HomeAppliances", "Name", c => c.String());
            AlterColumn("dbo.Manufacturers", "Email", c => c.String());
            AlterColumn("dbo.Manufacturers", "Address", c => c.String());
            AlterColumn("dbo.Manufacturers", "Name", c => c.String());
            AlterColumn("dbo.Cosmatics", "Category", c => c.String());
            AlterColumn("dbo.Cosmatics", "Name", c => c.String());
            DropColumn("dbo.WomenClothings", "Stock");
            DropColumn("dbo.MobilePhones", "Stock");
            DropColumn("dbo.MenClothings", "Stock");
            DropColumn("dbo.HomeAppliances", "Stock");
            DropColumn("dbo.Cosmatics", "Stock");
        }
    }
}
