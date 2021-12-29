namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddcommentmember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityComments", "MemberId", c => c.Int(nullable: false));
            AddColumn("dbo.BlogComments", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActivityComments", "MemberId");
            CreateIndex("dbo.BlogComments", "MemberId");
            AddForeignKey("dbo.ActivityComments", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.BlogComments", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogComments", "MemberId", "dbo.Members");
            DropForeignKey("dbo.ActivityComments", "MemberId", "dbo.Members");
            DropIndex("dbo.BlogComments", new[] { "MemberId" });
            DropIndex("dbo.ActivityComments", new[] { "MemberId" });
            DropColumn("dbo.BlogComments", "MemberId");
            DropColumn("dbo.ActivityComments", "MemberId");
        }
    }
}
