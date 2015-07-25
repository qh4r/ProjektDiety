namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Implementacjapoczątkowegoschematu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Fats = c.Double(nullable: false),
                        Carbohydrates = c.Double(nullable: false),
                        Proteins = c.Double(nullable: false),
                        Calories = c.Double(nullable: false),
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
            
            CreateTable(
                "dbo.RecipeComponents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Unit = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MealType = c.Int(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingHistoryRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Sport = c.Int(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        CaloriesBurned = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Bmi = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeightHistoryRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeightHistoryRecords");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Trainings");
            DropTable("dbo.TrainingHistoryRecords");
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeComponents");
            DropTable("dbo.MealHistoryRecords");
            DropTable("dbo.Ingredients");
        }
    }
}
