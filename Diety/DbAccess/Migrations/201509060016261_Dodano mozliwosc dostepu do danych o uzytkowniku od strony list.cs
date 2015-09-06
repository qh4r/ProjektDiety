namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodanomozliwoscdostepudodanychouzytkownikuodstronylist : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MealHistoryRecords", name: "UserProfileDb_Id", newName: "UserData_Id");
            RenameColumn(table: "dbo.TrainingHistoryRecords", name: "UserProfileDb_Id", newName: "UserData_Id");
            RenameColumn(table: "dbo.WeightHistoryRecords", name: "UserProfileDb_Id", newName: "UserData_Id");
            RenameIndex(table: "dbo.MealHistoryRecords", name: "IX_UserProfileDb_Id", newName: "IX_UserData_Id");
            RenameIndex(table: "dbo.TrainingHistoryRecords", name: "IX_UserProfileDb_Id", newName: "IX_UserData_Id");
            RenameIndex(table: "dbo.WeightHistoryRecords", name: "IX_UserProfileDb_Id", newName: "IX_UserData_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WeightHistoryRecords", name: "IX_UserData_Id", newName: "IX_UserProfileDb_Id");
            RenameIndex(table: "dbo.TrainingHistoryRecords", name: "IX_UserData_Id", newName: "IX_UserProfileDb_Id");
            RenameIndex(table: "dbo.MealHistoryRecords", name: "IX_UserData_Id", newName: "IX_UserProfileDb_Id");
            RenameColumn(table: "dbo.WeightHistoryRecords", name: "UserData_Id", newName: "UserProfileDb_Id");
            RenameColumn(table: "dbo.TrainingHistoryRecords", name: "UserData_Id", newName: "UserProfileDb_Id");
            RenameColumn(table: "dbo.MealHistoryRecords", name: "UserData_Id", newName: "UserProfileDb_Id");
        }
    }
}
