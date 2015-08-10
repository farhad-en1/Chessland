namespace ChessLandPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationcitytoaccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "City_CityId", c => c.Int());
            CreateIndex("dbo.Accounts", "City_CityId");
            AddForeignKey("dbo.Accounts", "City_CityId", "dbo.Cities", "CityId");
            DropColumn("dbo.Accounts", "styg");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "styg", c => c.String());
            DropForeignKey("dbo.Accounts", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Accounts", new[] { "City_CityId" });
            DropColumn("dbo.Accounts", "City_CityId");
        }
    }
}
