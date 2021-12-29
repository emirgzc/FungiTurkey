namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdatecontent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "About", c => c.String());
            AlterColumn("dbo.Services", "Content", c => c.String());
            AlterColumn("dbo.SettingsPages", "ServicesAbout", c => c.String());
            AlterColumn("dbo.SettingsPages", "GaleryAbout", c => c.String());
            AlterColumn("dbo.SettingsPages", "SponsorAbout", c => c.String());
            AlterColumn("dbo.SettingsPages", "ContactAbout", c => c.String());
            AlterColumn("dbo.SettingsPages", "TeamAbout", c => c.String());
            AlterColumn("dbo.SettingsPages", "StatisticAbout", c => c.String());
            AlterColumn("dbo.Sliders", "Content", c => c.String());
            AlterColumn("dbo.Statistics", "About", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Statistics", "About", c => c.String(maxLength: 100));
            AlterColumn("dbo.Sliders", "Content", c => c.String(maxLength: 500));
            AlterColumn("dbo.SettingsPages", "StatisticAbout", c => c.String(maxLength: 500));
            AlterColumn("dbo.SettingsPages", "TeamAbout", c => c.String(maxLength: 500));
            AlterColumn("dbo.SettingsPages", "ContactAbout", c => c.String(maxLength: 500));
            AlterColumn("dbo.SettingsPages", "SponsorAbout", c => c.String(maxLength: 500));
            AlterColumn("dbo.SettingsPages", "GaleryAbout", c => c.String(maxLength: 500));
            AlterColumn("dbo.SettingsPages", "ServicesAbout", c => c.String(maxLength: 500));
            AlterColumn("dbo.Services", "Content", c => c.String(maxLength: 750));
            AlterColumn("dbo.Members", "About", c => c.String(maxLength: 500));
        }
    }
}
