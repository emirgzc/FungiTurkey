namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddmemberjob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Job", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Job");
        }
    }
}
