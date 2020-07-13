namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Category_code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Category_code");
        }
    }
}
