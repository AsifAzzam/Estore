namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Cosmatics", "Category");
            DropColumn("dbo.HomeAppliances", "Category");
            DropColumn("dbo.MenClothings", "Category");
            DropColumn("dbo.MobilePhones", "Category");
            DropColumn("dbo.WomenClothings", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WomenClothings", "Category", c => c.String(nullable: false));
            AddColumn("dbo.MobilePhones", "Category", c => c.String(nullable: false));
            AddColumn("dbo.MenClothings", "Category", c => c.String(nullable: false));
            AddColumn("dbo.HomeAppliances", "Category", c => c.String(nullable: false));
            AddColumn("dbo.Cosmatics", "Category", c => c.String(nullable: false));
            DropTable("dbo.Categories");
        }
    }
}
