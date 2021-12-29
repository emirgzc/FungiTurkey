namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddcommentstatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityComments",
                c => new
                    {
                        ActvtyComId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Comment = c.String(maxLength: 600),
                        CommentDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ActId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActvtyComId)
                .ForeignKey("dbo.Activities", t => t.ActId, cascadeDelete: true)
                .Index(t => t.ActId);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        BlogComId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Comment = c.String(maxLength: 600),
                        CommentDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogComId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.ActivityComments", "ActId", "dbo.Activities");
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropIndex("dbo.ActivityComments", new[] { "ActId" });
            DropTable("dbo.BlogComments");
            DropTable("dbo.ActivityComments");
        }
    }
}
