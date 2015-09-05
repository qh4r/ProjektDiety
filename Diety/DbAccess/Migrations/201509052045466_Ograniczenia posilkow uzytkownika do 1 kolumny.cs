namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ograniczeniaposilkowuzytkownikado1kolumny : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MealHistoryRecords", "UserProfileDb_Id", c => c.Long());
            CreateIndex("dbo.MealHistoryRecords", "UserProfileDb_Id");
            AddForeignKey("dbo.MealHistoryRecords", "UserProfileDb_Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealHistoryRecords", "UserProfileDb_Id", "dbo.UserProfiles");
            DropIndex("dbo.MealHistoryRecords", new[] { "UserProfileDb_Id" });
            DropColumn("dbo.MealHistoryRecords", "UserProfileDb_Id");
        }
    }
}
