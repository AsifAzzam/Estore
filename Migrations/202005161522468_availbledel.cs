namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class availbledel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cosmatics", "Available");
            DropColumn("dbo.HomeAppliances", "Available");
            DropColumn("dbo.MenClothings", "Available");
            DropColumn("dbo.MobilePhones", "Available");
            DropColumn("dbo.WomenClothings", "Available");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WomenClothings", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.MobilePhones", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.MenClothings", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.HomeAppliances", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cosmatics", "Available", c => c.Boolean(nullable: false));
        }
    }
}
