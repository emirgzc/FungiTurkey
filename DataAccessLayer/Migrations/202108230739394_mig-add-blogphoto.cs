namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddblogphoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "ImageTwo", c => c.String(maxLength: 50));
            AddColumn("dbo.Blogs", "ImageTree", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "ImageTree");
            DropColumn("dbo.Blogs", "ImageTwo");
        }
    }
}
