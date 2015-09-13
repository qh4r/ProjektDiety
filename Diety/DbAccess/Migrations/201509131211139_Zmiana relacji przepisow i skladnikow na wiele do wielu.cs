namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zmianarelacjiprzepisowiskladnikownawieledowielu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeComponents", "RecipeDb_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeComponents", new[] { "RecipeDb_Id" });
            CreateTable(
                "dbo.RecipeComponentDbRecipeDbs",
                c => new
                    {
                        RecipeComponentDb_Id = c.Long(nullable: false),
                        RecipeDb_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeComponentDb_Id, t.RecipeDb_Id })
                .ForeignKey("dbo.RecipeComponents", t => t.RecipeComponentDb_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeDb_Id, cascadeDelete: true)
                .Index(t => t.RecipeComponentDb_Id)
                .Index(t => t.RecipeDb_Id);
            
            DropColumn("dbo.RecipeComponents", "RecipeDb_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeComponents", "RecipeDb_Id", c => c.Long());
            DropForeignKey("dbo.RecipeComponentDbRecipeDbs", "RecipeDb_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeComponentDbRecipeDbs", "RecipeComponentDb_Id", "dbo.RecipeComponents");
            DropIndex("dbo.RecipeComponentDbRecipeDbs", new[] { "RecipeDb_Id" });
            DropIndex("dbo.RecipeComponentDbRecipeDbs", new[] { "RecipeComponentDb_Id" });
            DropTable("dbo.RecipeComponentDbRecipeDbs");
            CreateIndex("dbo.RecipeComponents", "RecipeDb_Id");
            AddForeignKey("dbo.RecipeComponents", "RecipeDb_Id", "dbo.Recipes", "Id");
        }
    }
}
