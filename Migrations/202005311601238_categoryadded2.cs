namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryadded2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cosmatics", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.HomeAppliances", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.MenClothings", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.MobilePhones", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.WomenClothings", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cosmatics", "CategoryId");
            CreateIndex("dbo.HomeAppliances", "CategoryId");
            CreateIndex("dbo.MenClothings", "CategoryId");
            CreateIndex("dbo.MobilePhones", "CategoryId");
            CreateIndex("dbo.WomenClothings", "CategoryId");
            AddForeignKey("dbo.Cosmatics", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HomeAppliances", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenClothings", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MobilePhones", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WomenClothings", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WomenClothings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.MobilePhones", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.MenClothings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.HomeAppliances", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Cosmatics", "CategoryId", "dbo.Categories");
            DropIndex("dbo.WomenClothings", new[] { "CategoryId" });
            DropIndex("dbo.MobilePhones", new[] { "CategoryId" });
            DropIndex("dbo.MenClothings", new[] { "CategoryId" });
            DropIndex("dbo.HomeAppliances", new[] { "CategoryId" });
            DropIndex("dbo.Cosmatics", new[] { "CategoryId" });
            DropColumn("dbo.WomenClothings", "CategoryId");
            DropColumn("dbo.MobilePhones", "CategoryId");
            DropColumn("dbo.MenClothings", "CategoryId");
            DropColumn("dbo.HomeAppliances", "CategoryId");
            DropColumn("dbo.Cosmatics", "CategoryId");
        }
    }
}
