namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Poprawkiorazzmianamapowańzinterfejsównaichimplementacje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MealHistoryRecords", "IsPast", c => c.Boolean(nullable: false));
            AddColumn("dbo.MealHistoryRecords", "RecipeData_Id", c => c.Long());
            AddColumn("dbo.MealHistoryRecords", "UserProfile_Id", c => c.Long());
            AddColumn("dbo.MealHistoryRecords", "UserProfile_Id1", c => c.Long());
            AddColumn("dbo.RecipeComponents", "IngredientData_Id", c => c.Long());
            AddColumn("dbo.RecipeComponents", "Recipe_Id", c => c.Long());
            AddColumn("dbo.TrainingHistoryRecords", "TrainingData_Id", c => c.Long());
            AddColumn("dbo.TrainingHistoryRecords", "UserProfile_Id", c => c.Long());
            AddColumn("dbo.WeightHistoryRecords", "UserProfile_Id", c => c.Long());
            CreateIndex("dbo.MealHistoryRecords", "RecipeData_Id");
            CreateIndex("dbo.MealHistoryRecords", "UserProfile_Id");
            CreateIndex("dbo.MealHistoryRecords", "UserProfile_Id1");
            CreateIndex("dbo.RecipeComponents", "IngredientData_Id");
            CreateIndex("dbo.RecipeComponents", "Recipe_Id");
            CreateIndex("dbo.TrainingHistoryRecords", "TrainingData_Id");
            CreateIndex("dbo.TrainingHistoryRecords", "UserProfile_Id");
            CreateIndex("dbo.WeightHistoryRecords", "UserProfile_Id");
            AddForeignKey("dbo.RecipeComponents", "IngredientData_Id", "dbo.Ingredients", "Id");
            AddForeignKey("dbo.RecipeComponents", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.MealHistoryRecords", "RecipeData_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.TrainingHistoryRecords", "TrainingData_Id", "dbo.Trainings", "Id");
            AddForeignKey("dbo.MealHistoryRecords", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.MealHistoryRecords", "UserProfile_Id1", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.TrainingHistoryRecords", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.WeightHistoryRecords", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeightHistoryRecords", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.TrainingHistoryRecords", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.MealHistoryRecords", "UserProfile_Id1", "dbo.UserProfiles");
            DropForeignKey("dbo.MealHistoryRecords", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.TrainingHistoryRecords", "TrainingData_Id", "dbo.Trainings");
            DropForeignKey("dbo.MealHistoryRecords", "RecipeData_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeComponents", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeComponents", "IngredientData_Id", "dbo.Ingredients");
            DropIndex("dbo.WeightHistoryRecords", new[] { "UserProfile_Id" });
            DropIndex("dbo.TrainingHistoryRecords", new[] { "UserProfile_Id" });
            DropIndex("dbo.TrainingHistoryRecords", new[] { "TrainingData_Id" });
            DropIndex("dbo.RecipeComponents", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeComponents", new[] { "IngredientData_Id" });
            DropIndex("dbo.MealHistoryRecords", new[] { "UserProfile_Id1" });
            DropIndex("dbo.MealHistoryRecords", new[] { "UserProfile_Id" });
            DropIndex("dbo.MealHistoryRecords", new[] { "RecipeData_Id" });
            DropColumn("dbo.WeightHistoryRecords", "UserProfile_Id");
            DropColumn("dbo.TrainingHistoryRecords", "UserProfile_Id");
            DropColumn("dbo.TrainingHistoryRecords", "TrainingData_Id");
            DropColumn("dbo.RecipeComponents", "Recipe_Id");
            DropColumn("dbo.RecipeComponents", "IngredientData_Id");
            DropColumn("dbo.MealHistoryRecords", "UserProfile_Id1");
            DropColumn("dbo.MealHistoryRecords", "UserProfile_Id");
            DropColumn("dbo.MealHistoryRecords", "RecipeData_Id");
            DropColumn("dbo.MealHistoryRecords", "IsPast");
        }
    }
}
