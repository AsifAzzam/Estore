namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chng_in_color_of_Clothes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeAppliances", "Colors", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomeAppliances", "Colors");
        }
    }
}
