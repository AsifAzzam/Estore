namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attrtomobile : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MobilePhones", "ScreenSize", c => c.String(nullable: false));
            AlterColumn("dbo.MobilePhones", "Display", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MobilePhones", "Display", c => c.String());
            AlterColumn("dbo.MobilePhones", "ScreenSize", c => c.String());
        }
    }
}
