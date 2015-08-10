namespace ChessLandPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allmodelsadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 50),
                        MobilePhone = c.String(maxLength: 12),
                        styg = c.String(),
                        Gender = c.Byte(),
                        Enable = c.Boolean(nullable: false),
                        LastLoginTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.TicketQstions",
                c => new
                    {
                        QstionId = c.Int(nullable: false, identity: true),
                        QstionTitle = c.String(nullable: false, maxLength: 50),
                        QstionContent = c.String(nullable: false, maxLength: 500),
                        RegTime = c.DateTime(nullable: false),
                        FkAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QstionId)
                .ForeignKey("dbo.Accounts", t => t.FkAccountId, cascadeDelete: true)
                .Index(t => t.FkAccountId);
            
            CreateTable(
                "dbo.TicketAnswers",
                c => new
                    {
                        AnsId = c.Int(nullable: false),
                        AnsContent = c.String(nullable: false, maxLength: 500),
                        AnsReTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.AnsId)
                .ForeignKey("dbo.TicketQstions", t => t.AnsId, cascadeDelete: true)
                .Index(t => t.AnsId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        FkProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Provinces", t => t.FkProvinceId, cascadeDelete: true)
                .Index(t => t.FkProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(maxLength: 50),
                        FkCountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId)
                .ForeignKey("dbo.Countries", t => t.FkCountryId, cascadeDelete: true)
                .Index(t => t.FkCountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(maxLength: 50),
                        LatinName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ComTitlle = c.String(nullable: false, maxLength: 50),
                        ComContent = c.String(nullable: false, maxLength: 500),
                        ComTime = c.DateTime(nullable: false),
                        Cominfo_CommnenterFullName = c.String(nullable: false, maxLength: 50),
                        Cominfo_CommenterMail = c.String(nullable: false, maxLength: 50),
                        Cominfo_CommenterIpAddress = c.String(maxLength: 50),
                        Cominfo_CommeterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provinces", "FkCountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "FkProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.TicketAnswers", "AnsId", "dbo.TicketQstions");
            DropForeignKey("dbo.TicketQstions", "FkAccountId", "dbo.Accounts");
            DropIndex("dbo.Provinces", new[] { "FkCountryId" });
            DropIndex("dbo.Cities", new[] { "FkProvinceId" });
            DropIndex("dbo.TicketAnswers", new[] { "AnsId" });
            DropIndex("dbo.TicketQstions", new[] { "FkAccountId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Countries");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.TicketAnswers");
            DropTable("dbo.TicketQstions");
            DropTable("dbo.Accounts");
        }
    }
}
