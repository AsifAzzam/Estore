namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgtomobile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MobilePhones", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MobilePhones", "Image");
        }
    }
}
