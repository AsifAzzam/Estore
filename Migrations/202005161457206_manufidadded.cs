namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manufidadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cosmatics", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.HomeAppliances", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.MenClothings", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.MobilePhones", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.WomenClothings", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.Cosmatics", new[] { "Manufacturer_Id" });
            DropIndex("dbo.HomeAppliances", new[] { "Manufacturer_Id" });
            DropIndex("dbo.MenClothings", new[] { "Manufacturer_Id" });
            DropIndex("dbo.MobilePhones", new[] { "Manufacturer_Id" });
            DropIndex("dbo.WomenClothings", new[] { "Manufacturer_Id" });
            RenameColumn(table: "dbo.Cosmatics", name: "Manufacturer_Id", newName: "ManufacturerId");
            RenameColumn(table: "dbo.HomeAppliances", name: "Manufacturer_Id", newName: "ManufacturerId");
            RenameColumn(table: "dbo.MenClothings", name: "Manufacturer_Id", newName: "ManufacturerId");
            RenameColumn(table: "dbo.MobilePhones", name: "Manufacturer_Id", newName: "ManufacturerId");
            RenameColumn(table: "dbo.WomenClothings", name: "Manufacturer_Id", newName: "ManufacturerId");
            AlterColumn("dbo.Cosmatics", "ManufacturerId", c => c.Int(nullable: false));
            AlterColumn("dbo.HomeAppliances", "ManufacturerId", c => c.Int(nullable: false));
            AlterColumn("dbo.MenClothings", "ManufacturerId", c => c.Int(nullable: false));
            AlterColumn("dbo.MobilePhones", "ManufacturerId", c => c.Int(nullable: false));
            AlterColumn("dbo.WomenClothings", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cosmatics", "ManufacturerId");
            CreateIndex("dbo.HomeAppliances", "ManufacturerId");
            CreateIndex("dbo.MenClothings", "ManufacturerId");
            CreateIndex("dbo.MobilePhones", "ManufacturerId");
            CreateIndex("dbo.WomenClothings", "ManufacturerId");
            AddForeignKey("dbo.Cosmatics", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HomeAppliances", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenClothings", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MobilePhones", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WomenClothings", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WomenClothings", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.MobilePhones", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.MenClothings", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.HomeAppliances", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cosmatics", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.WomenClothings", new[] { "ManufacturerId" });
            DropIndex("dbo.MobilePhones", new[] { "ManufacturerId" });
            DropIndex("dbo.MenClothings", new[] { "ManufacturerId" });
            DropIndex("dbo.HomeAppliances", new[] { "ManufacturerId" });
            DropIndex("dbo.Cosmatics", new[] { "ManufacturerId" });
            AlterColumn("dbo.WomenClothings", "ManufacturerId", c => c.Int());
            AlterColumn("dbo.MobilePhones", "ManufacturerId", c => c.Int());
            AlterColumn("dbo.MenClothings", "ManufacturerId", c => c.Int());
            AlterColumn("dbo.HomeAppliances", "ManufacturerId", c => c.Int());
            AlterColumn("dbo.Cosmatics", "ManufacturerId", c => c.Int());
            RenameColumn(table: "dbo.WomenClothings", name: "ManufacturerId", newName: "Manufacturer_Id");
            RenameColumn(table: "dbo.MobilePhones", name: "ManufacturerId", newName: "Manufacturer_Id");
            RenameColumn(table: "dbo.MenClothings", name: "ManufacturerId", newName: "Manufacturer_Id");
            RenameColumn(table: "dbo.HomeAppliances", name: "ManufacturerId", newName: "Manufacturer_Id");
            RenameColumn(table: "dbo.Cosmatics", name: "ManufacturerId", newName: "Manufacturer_Id");
            CreateIndex("dbo.WomenClothings", "Manufacturer_Id");
            CreateIndex("dbo.MobilePhones", "Manufacturer_Id");
            CreateIndex("dbo.MenClothings", "Manufacturer_Id");
            CreateIndex("dbo.HomeAppliances", "Manufacturer_Id");
            CreateIndex("dbo.Cosmatics", "Manufacturer_Id");
            AddForeignKey("dbo.WomenClothings", "Manufacturer_Id", "dbo.Manufacturers", "Id");
            AddForeignKey("dbo.MobilePhones", "Manufacturer_Id", "dbo.Manufacturers", "Id");
            AddForeignKey("dbo.MenClothings", "Manufacturer_Id", "dbo.Manufacturers", "Id");
            AddForeignKey("dbo.HomeAppliances", "Manufacturer_Id", "dbo.Manufacturers", "Id");
            AddForeignKey("dbo.Cosmatics", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
    }
}
