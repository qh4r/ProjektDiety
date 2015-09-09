namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodanohasloiindexnanazwieuzytkownika : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "HashedPassword", c => c.String());
            AlterColumn("dbo.UserProfiles", "UserName", c => c.String(maxLength: 20));
            CreateIndex("dbo.UserProfiles", "UserName", unique: true, name: "UserUnique");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserProfiles", "UserUnique");
            AlterColumn("dbo.UserProfiles", "UserName", c => c.String());
            DropColumn("dbo.UserProfiles", "HashedPassword");
        }
    }
}
