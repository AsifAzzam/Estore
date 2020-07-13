namespace PersonalEstore.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clothingchanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MenClothings", newName: "Clothings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Clothings", newName: "MenClothings");
        }
    }
}
