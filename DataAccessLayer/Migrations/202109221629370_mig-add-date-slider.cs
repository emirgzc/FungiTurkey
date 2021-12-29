namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migadddateslider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "SliderAddDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "SliderAddDate");
        }
    }
}
