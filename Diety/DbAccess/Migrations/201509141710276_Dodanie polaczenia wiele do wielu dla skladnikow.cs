namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodaniepolaczeniawieledowieludlaskladnikow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeComponentDbRecipeDbs", "RecipeComponentDb_Id", "dbo.RecipeComponents");
            DropForeignKey("dbo.RecipeComponentDbRecipeDbs", "RecipeDb_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeComponentDbRecipeDbs", new[] { "RecipeComponentDb_Id" });
            DropIndex("dbo.RecipeComponentDbRecipeDbs", new[] { "RecipeDb_Id" });
            AddColumn("dbo.RecipeComponents", "RecipeDb_Id", c => c.Long());
            CreateIndex("dbo.RecipeComponents", "RecipeDb_Id");
            AddForeignKey("dbo.RecipeComponents", "RecipeDb_Id", "dbo.Recipes", "Id");
            DropTable("dbo.RecipeComponentDbRecipeDbs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeComponentDbRecipeDbs",
                c => new
                    {
                        RecipeComponentDb_Id = c.Long(nullable: false),
                        RecipeDb_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeComponentDb_Id, t.RecipeDb_Id });
            
            DropForeignKey("dbo.RecipeComponents", "RecipeDb_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeComponents", new[] { "RecipeDb_Id" });
            DropColumn("dbo.RecipeComponents", "RecipeDb_Id");
            CreateIndex("dbo.RecipeComponentDbRecipeDbs", "RecipeDb_Id");
            CreateIndex("dbo.RecipeComponentDbRecipeDbs", "RecipeComponentDb_Id");
            AddForeignKey("dbo.RecipeComponentDbRecipeDbs", "RecipeDb_Id", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeComponentDbRecipeDbs", "RecipeComponentDb_Id", "dbo.RecipeComponents", "Id", cascadeDelete: true);
        }
    }
}
