namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdatepublicc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityComments", "ActId", "dbo.Activities");
            DropForeignKey("dbo.ActivityComments", "MemberId", "dbo.Members");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogComments", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Records", "ActId", "dbo.Activities");
            DropForeignKey("dbo.Records", "MemberId", "dbo.Members");
            DropIndex("dbo.ActivityComments", new[] { "ActId" });
            DropIndex("dbo.ActivityComments", new[] { "MemberId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropIndex("dbo.BlogComments", new[] { "MemberId" });
            DropIndex("dbo.Records", new[] { "ActId" });
            DropIndex("dbo.Records", new[] { "MemberId" });
            DropColumn("dbo.ActivityComments", "ActId");
            DropColumn("dbo.ActivityComments", "MemberId");
            DropColumn("dbo.Members", "Status");
            DropColumn("dbo.BlogComments", "BlogId");
            DropColumn("dbo.BlogComments", "MemberId");
            DropColumn("dbo.Blogs", "ImageTwo");
            DropColumn("dbo.Blogs", "ImageTree");
            DropColumn("dbo.Records", "ActId");
            DropColumn("dbo.Records", "MemberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Records", "MemberId", c => c.Int(nullable: false));
            AddColumn("dbo.Records", "ActId", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "ImageTree", c => c.String(maxLength: 50));
            AddColumn("dbo.Blogs", "ImageTwo", c => c.String(maxLength: 50));
            AddColumn("dbo.BlogComments", "MemberId", c => c.Int(nullable: false));
            AddColumn("dbo.BlogComments", "BlogId", c => c.Int(nullable: false));
            AddColumn("dbo.Members", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ActivityComments", "MemberId", c => c.Int(nullable: false));
            AddColumn("dbo.ActivityComments", "ActId", c => c.Int(nullable: false));
            CreateIndex("dbo.Records", "MemberId");
            CreateIndex("dbo.Records", "ActId");
            CreateIndex("dbo.BlogComments", "MemberId");
            CreateIndex("dbo.BlogComments", "BlogId");
            CreateIndex("dbo.ActivityComments", "MemberId");
            CreateIndex("dbo.ActivityComments", "ActId");
            AddForeignKey("dbo.Records", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.Records", "ActId", "dbo.Activities", "ActId", cascadeDelete: true);
            AddForeignKey("dbo.BlogComments", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
            AddForeignKey("dbo.ActivityComments", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.ActivityComments", "ActId", "dbo.Activities", "ActId", cascadeDelete: true);
        }
    }
}
