namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdatepublicc2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityComments", "ActId", c => c.Int(nullable: false));
            AddColumn("dbo.ActivityComments", "MemberId", c => c.Int(nullable: false));
            AddColumn("dbo.BlogComments", "BlogId", c => c.Int(nullable: false));
            AddColumn("dbo.BlogComments", "MemberId", c => c.Int(nullable: false));
            AddColumn("dbo.Records", "ActId", c => c.Int(nullable: false));
            AddColumn("dbo.Records", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActivityComments", "ActId");
            CreateIndex("dbo.ActivityComments", "MemberId");
            CreateIndex("dbo.BlogComments", "BlogId");
            CreateIndex("dbo.BlogComments", "MemberId");
            CreateIndex("dbo.Records", "ActId");
            CreateIndex("dbo.Records", "MemberId");
            AddForeignKey("dbo.ActivityComments", "ActId", "dbo.Activities", "ActId", cascadeDelete: true);
            AddForeignKey("dbo.ActivityComments", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
            AddForeignKey("dbo.BlogComments", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.Records", "ActId", "dbo.Activities", "ActId", cascadeDelete: true);
            AddForeignKey("dbo.Records", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Records", "ActId", "dbo.Activities");
            DropForeignKey("dbo.BlogComments", "MemberId", "dbo.Members");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.ActivityComments", "MemberId", "dbo.Members");
            DropForeignKey("dbo.ActivityComments", "ActId", "dbo.Activities");
            DropIndex("dbo.Records", new[] { "MemberId" });
            DropIndex("dbo.Records", new[] { "ActId" });
            DropIndex("dbo.BlogComments", new[] { "MemberId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropIndex("dbo.ActivityComments", new[] { "MemberId" });
            DropIndex("dbo.ActivityComments", new[] { "ActId" });
            DropColumn("dbo.Records", "MemberId");
            DropColumn("dbo.Records", "ActId");
            DropColumn("dbo.BlogComments", "MemberId");
            DropColumn("dbo.BlogComments", "BlogId");
            DropColumn("dbo.ActivityComments", "MemberId");
            DropColumn("dbo.ActivityComments", "ActId");
        }
    }
}
