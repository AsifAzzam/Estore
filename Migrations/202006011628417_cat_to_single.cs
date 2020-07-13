namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cat_to_single : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Categories", name: "Category_Id", newName: "ParentId");
            AlterColumn("dbo.Categories", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "ParentId" });
            AlterColumn("dbo.Categories", "ParentId", c => c.Int());
            RenameColumn(table: "dbo.Categories", name: "ParentId", newName: "Category_Id");
            CreateIndex("dbo.Categories", "Category_Id");
        }
    }
}
