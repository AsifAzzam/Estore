namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Parent_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Parent_Id");
            AddForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropColumn("dbo.Categories", "Parent_Id");
        }
    }
}
