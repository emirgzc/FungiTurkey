namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        Mission = c.String(),
                        Vision = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Content = c.String(),
                        Image = c.String(maxLength: 50),
                        StartDate = c.String(maxLength: 50),
                        FinishDate = c.String(maxLength: 50),
                        LastRecordDate = c.String(maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Director = c.String(maxLength: 50),
                        Quota = c.Int(nullable: false),
                        StatusAct = c.Boolean(nullable: false),
                        StatusRecord = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ActId);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        PeopleNumber = c.Int(nullable: false),
                        RecordDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ActId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Activities", t => t.ActId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.ActId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        About = c.String(maxLength: 500),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Content = c.String(),
                        Image = c.String(maxLength: 50),
                        Author = c.String(maxLength: 50),
                        BlogDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        Message = c.String(),
                        ContactDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Galeries",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Image = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServicesId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Content = c.String(maxLength: 750),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServicesId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SetId = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        DirectorName = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 50),
                        Twitter = c.String(maxLength: 50),
                        Linkedin = c.String(maxLength: 50),
                        Instagram = c.String(maxLength: 50),
                        Youtube = c.String(maxLength: 50),
                        Map = c.String(maxLength: 700),
                        DeveloperName = c.String(maxLength: 50),
                        CopyrightSite = c.String(maxLength: 100),
                        RizaMetni = c.String(),
                    })
                .PrimaryKey(t => t.SetId);
            
            CreateTable(
                "dbo.SettingsPages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        ServicesTitle = c.String(maxLength: 50),
                        ServicesAbout = c.String(maxLength: 500),
                        GaleryTitle = c.String(maxLength: 50),
                        GaleryAbout = c.String(maxLength: 500),
                        SponsorTitle = c.String(maxLength: 50),
                        SponsorAbout = c.String(maxLength: 500),
                        ContactTitle = c.String(maxLength: 50),
                        ContactAbout = c.String(maxLength: 500),
                        TeamTitle = c.String(maxLength: 50),
                        TeamAbout = c.String(maxLength: 500),
                        StatisticTitle = c.String(maxLength: 50),
                        StatisticAbout = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.PageId);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Content = c.String(maxLength: 500),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SliderId);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        SponsorId = c.Int(nullable: false, identity: true),
                        SponsorName = c.String(maxLength: 100),
                        SponsorDirector = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SponsorId);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        StatId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Value = c.String(maxLength: 10),
                        About = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StatId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        About = c.String(maxLength: 500),
                        Job = c.String(maxLength: 50),
                        Image = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 50),
                        Twitter = c.String(maxLength: 50),
                        Linkedin = c.String(maxLength: 50),
                        Instagram = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Records", "ActId", "dbo.Activities");
            DropIndex("dbo.Records", new[] { "MemberId" });
            DropIndex("dbo.Records", new[] { "ActId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Statistics");
            DropTable("dbo.Sponsors");
            DropTable("dbo.Sliders");
            DropTable("dbo.SettingsPages");
            DropTable("dbo.Settings");
            DropTable("dbo.Services");
            DropTable("dbo.Galeries");
            DropTable("dbo.Contacts");
            DropTable("dbo.Blogs");
            DropTable("dbo.Admins");
            DropTable("dbo.Members");
            DropTable("dbo.Records");
            DropTable("dbo.Activities");
            DropTable("dbo.Abouts");
        }
    }
}
