namespace TestBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Subtitle", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Category", c => c.String());
            AlterColumn("dbo.Posts", "Subtitle", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
        }
    }
}
