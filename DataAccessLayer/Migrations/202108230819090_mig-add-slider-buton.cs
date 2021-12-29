namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddsliderbuton : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "ButonHref", c => c.String(maxLength: 50));
            AddColumn("dbo.Sliders", "ButonTitle", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "ButonTitle");
            DropColumn("dbo.Sliders", "ButonHref");
        }
    }
}
