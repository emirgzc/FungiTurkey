namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdatesetmil : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Settings", "Address", c => c.String(maxLength: 70));
            AlterColumn("dbo.Settings", "Phone", c => c.String(maxLength: 70));
            AlterColumn("dbo.Settings", "Email", c => c.String(maxLength: 70));
            AlterColumn("dbo.Settings", "DirectorName", c => c.String(maxLength: 70));
            AlterColumn("dbo.Settings", "Facebook", c => c.String(maxLength: 70));
            AlterColumn("dbo.Settings", "Twitter", c => c.String(maxLength: 70));
            AlterColumn("dbo.Settings", "Linkedin", c => c.String(maxLength: 70));
            AlterColumn("dbo.Settings", "Instagram", c => c.String(maxLength: 70));
            AlterColumn("dbo.Settings", "Youtube", c => c.String(maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Settings", "Youtube", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "Instagram", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "Linkedin", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "Twitter", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "Facebook", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "DirectorName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "Phone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "Address", c => c.String(maxLength: 50));
        }
    }
}
