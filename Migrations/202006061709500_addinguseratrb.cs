namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinguseratrb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsAdmin");
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
