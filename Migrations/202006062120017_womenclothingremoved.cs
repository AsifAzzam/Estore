namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class womenclothingremoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WomenClothings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.WomenClothings", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.WomenClothings", new[] { "ManufacturerId" });
            DropIndex("dbo.WomenClothings", new[] { "CategoryId" });
            DropTable("dbo.WomenClothings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WomenClothings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Size = c.String(),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.WomenClothings", "CategoryId");
            CreateIndex("dbo.WomenClothings", "ManufacturerId");
            AddForeignKey("dbo.WomenClothings", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WomenClothings", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
