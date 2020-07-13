namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_moved_to_Item : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cosmatics", "Image", c => c.String());
            AddColumn("dbo.HomeAppliances", "Image", c => c.String());
            AddColumn("dbo.MenClothings", "Image", c => c.String());
            AddColumn("dbo.WomenClothings", "Image", c => c.String());
            AlterColumn("dbo.MobilePhones", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MobilePhones", "Image", c => c.String(nullable: false));
            DropColumn("dbo.WomenClothings", "Image");
            DropColumn("dbo.MenClothings", "Image");
            DropColumn("dbo.HomeAppliances", "Image");
            DropColumn("dbo.Cosmatics", "Image");
        }
    }
}
