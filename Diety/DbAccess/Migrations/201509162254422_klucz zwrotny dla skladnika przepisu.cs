namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kluczzwrotnydlaskladnikaprzepisu : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RecipeComponents", name: "RecipeDb_Id", newName: "OwnerComponent_Id");
            RenameIndex(table: "dbo.RecipeComponents", name: "IX_RecipeDb_Id", newName: "IX_OwnerComponent_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RecipeComponents", name: "IX_OwnerComponent_Id", newName: "IX_RecipeDb_Id");
            RenameColumn(table: "dbo.RecipeComponents", name: "OwnerComponent_Id", newName: "RecipeDb_Id");
        }
    }
}
