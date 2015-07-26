namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Poprawanazewnictwa : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RecipeComponents", name: "Recipe_Id", newName: "RecipeDb_Id");
            RenameColumn(table: "dbo.MealHistoryRecords", name: "UserProfile_Id", newName: "UserProfileDb_Id");
            RenameColumn(table: "dbo.MealHistoryRecords", name: "UserProfile_Id1", newName: "UserProfileDb_Id1");
            RenameColumn(table: "dbo.TrainingHistoryRecords", name: "UserProfile_Id", newName: "UserProfileDb_Id");
            RenameColumn(table: "dbo.WeightHistoryRecords", name: "UserProfile_Id", newName: "UserProfileDb_Id");
            RenameIndex(table: "dbo.MealHistoryRecords", name: "IX_UserProfile_Id", newName: "IX_UserProfileDb_Id");
            RenameIndex(table: "dbo.MealHistoryRecords", name: "IX_UserProfile_Id1", newName: "IX_UserProfileDb_Id1");
            RenameIndex(table: "dbo.RecipeComponents", name: "IX_Recipe_Id", newName: "IX_RecipeDb_Id");
            RenameIndex(table: "dbo.TrainingHistoryRecords", name: "IX_UserProfile_Id", newName: "IX_UserProfileDb_Id");
            RenameIndex(table: "dbo.WeightHistoryRecords", name: "IX_UserProfile_Id", newName: "IX_UserProfileDb_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WeightHistoryRecords", name: "IX_UserProfileDb_Id", newName: "IX_UserProfile_Id");
            RenameIndex(table: "dbo.TrainingHistoryRecords", name: "IX_UserProfileDb_Id", newName: "IX_UserProfile_Id");
            RenameIndex(table: "dbo.RecipeComponents", name: "IX_RecipeDb_Id", newName: "IX_Recipe_Id");
            RenameIndex(table: "dbo.MealHistoryRecords", name: "IX_UserProfileDb_Id1", newName: "IX_UserProfile_Id1");
            RenameIndex(table: "dbo.MealHistoryRecords", name: "IX_UserProfileDb_Id", newName: "IX_UserProfile_Id");
            RenameColumn(table: "dbo.WeightHistoryRecords", name: "UserProfileDb_Id", newName: "UserProfile_Id");
            RenameColumn(table: "dbo.TrainingHistoryRecords", name: "UserProfileDb_Id", newName: "UserProfile_Id");
            RenameColumn(table: "dbo.MealHistoryRecords", name: "UserProfileDb_Id1", newName: "UserProfile_Id1");
            RenameColumn(table: "dbo.MealHistoryRecords", name: "UserProfileDb_Id", newName: "UserProfile_Id");
            RenameColumn(table: "dbo.RecipeComponents", name: "RecipeDb_Id", newName: "Recipe_Id");
        }
    }
}
