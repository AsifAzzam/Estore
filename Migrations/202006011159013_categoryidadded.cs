namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryidadded : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            RenameColumn(table: "dbo.Categories", name: "Parent_Id", newName: "ParentId");
            AlterColumn("dbo.Categories", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "ParentId" });
            AlterColumn("dbo.Categories", "ParentId", c => c.Int());
            RenameColumn(table: "dbo.Categories", name: "ParentId", newName: "Parent_Id");
            CreateIndex("dbo.Categories", "Parent_Id");
        }
    }
}
