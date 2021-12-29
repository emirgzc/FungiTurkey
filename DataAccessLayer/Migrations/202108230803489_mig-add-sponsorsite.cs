namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddsponsorsite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sponsors", "SponsorWebSite", c => c.String(maxLength: 100));
            DropColumn("dbo.Sponsors", "SponsorDirector");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sponsors", "SponsorDirector", c => c.String(maxLength: 100));
            DropColumn("dbo.Sponsors", "SponsorWebSite");
        }
    }
}
