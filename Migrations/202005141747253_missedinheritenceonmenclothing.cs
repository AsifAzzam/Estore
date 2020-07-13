namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class missedinheritenceonmenclothing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenClothings", "Name", c => c.String());
            AddColumn("dbo.MenClothings", "price", c => c.Int(nullable: false));
            AddColumn("dbo.MenClothings", "Category", c => c.String());
            AddColumn("dbo.MenClothings", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.MenClothings", "Manufacturer_Id", c => c.Int());
            CreateIndex("dbo.MenClothings", "Manufacturer_Id");
            AddForeignKey("dbo.MenClothings", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenClothings", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.MenClothings", new[] { "Manufacturer_Id" });
            DropColumn("dbo.MenClothings", "Manufacturer_Id");
            DropColumn("dbo.MenClothings", "Available");
            DropColumn("dbo.MenClothings", "Category");
            DropColumn("dbo.MenClothings", "price");
            DropColumn("dbo.MenClothings", "Name");
        }
    }
}
