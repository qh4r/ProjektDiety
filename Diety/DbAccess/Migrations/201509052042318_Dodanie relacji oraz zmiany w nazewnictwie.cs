namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodanierelacjiorazzmianywnazewnictwie : DbMigration
    {
        public override void Up()
        {
			DropTable("dbo.MealHistoryRecords");
			DropTable("dbo.TrainingHistoryRecords");
            CreateTable(
                "dbo.MealHistoryRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsPast = c.Boolean(nullable: false),
                        RecipeData_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeData_Id)
                .Index(t => t.RecipeData_Id);
            
            CreateTable(
                "dbo.TrainingHistoryRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TrainingData_Id = c.Long(),
                        UserProfileDb_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainings", t => t.TrainingData_Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileDb_Id)
                .Index(t => t.TrainingData_Id)
                .Index(t => t.UserProfileDb_Id);
            
            AddColumn("dbo.RecipeComponents", "IngredientData_Id", c => c.Long());
            AddColumn("dbo.RecipeComponents", "RecipeDb_Id", c => c.Long());
            AddColumn("dbo.WeightHistoryRecords", "UserProfileDb_Id", c => c.Long());
            CreateIndex("dbo.RecipeComponents", "IngredientData_Id");
            CreateIndex("dbo.RecipeComponents", "RecipeDb_Id");
            CreateIndex("dbo.WeightHistoryRecords", "UserProfileDb_Id");
            AddForeignKey("dbo.RecipeComponents", "IngredientData_Id", "dbo.Ingredients", "Id");
            AddForeignKey("dbo.RecipeComponents", "RecipeDb_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.WeightHistoryRecords", "UserProfileDb_Id", "dbo.UserProfiles", "Id");

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TrainingHistoryRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MealHistoryRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.WeightHistoryRecords", "UserProfileDb_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.TrainingHistoryRecords", "UserProfileDb_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.TrainingHistoryRecords", "TrainingData_Id", "dbo.Trainings");
            DropForeignKey("dbo.MealHistoryRecords", "RecipeData_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeComponents", "RecipeDb_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeComponents", "IngredientData_Id", "dbo.Ingredients");
            DropIndex("dbo.WeightHistoryRecords", new[] { "UserProfileDb_Id" });
            DropIndex("dbo.TrainingHistoryRecords", new[] { "UserProfileDb_Id" });
            DropIndex("dbo.TrainingHistoryRecords", new[] { "TrainingData_Id" });
            DropIndex("dbo.RecipeComponents", new[] { "RecipeDb_Id" });
            DropIndex("dbo.RecipeComponents", new[] { "IngredientData_Id" });
            DropIndex("dbo.MealHistoryRecords", new[] { "RecipeData_Id" });
            DropColumn("dbo.WeightHistoryRecords", "UserProfileDb_Id");
            DropColumn("dbo.RecipeComponents", "RecipeDb_Id");
            DropColumn("dbo.RecipeComponents", "IngredientData_Id");
            DropTable("dbo.TrainingHistoryRecords");
            DropTable("dbo.MealHistoryRecords");
        }
    }
}
