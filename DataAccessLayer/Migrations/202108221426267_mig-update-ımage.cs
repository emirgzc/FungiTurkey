namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdateımage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Image", c => c.String(maxLength: 80));
            AddColumn("dbo.Sponsors", "Image", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sponsors", "Image");
            DropColumn("dbo.Services", "Image");
        }
    }
}
