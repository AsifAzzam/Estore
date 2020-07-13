namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testcatlist : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "ParentId" });
            RenameColumn(table: "dbo.Categories", name: "ParentId", newName: "Category_Id");
            AlterColumn("dbo.Categories", "Category_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Category_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            AlterColumn("dbo.Categories", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Categories", name: "Category_Id", newName: "ParentId");
            CreateIndex("dbo.Categories", "ParentId");
        }
    }
}
