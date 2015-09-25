namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zmianadatynanullowalna : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MealHistoryRecords", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MealHistoryRecords", "Date", c => c.DateTime(nullable: false));
        }
    }
}
