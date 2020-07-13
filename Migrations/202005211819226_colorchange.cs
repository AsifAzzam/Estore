namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colorchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MobilePhones", "Colors", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MobilePhones", "Colors");
        }
    }
}
