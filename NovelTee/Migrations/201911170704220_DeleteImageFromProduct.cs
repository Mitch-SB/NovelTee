namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteImageFromProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ImageId", "dbo.Images");
            DropIndex("dbo.Products", new[] { "ImageId" });
            DropColumn("dbo.Products", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ImageId");
            AddForeignKey("dbo.Products", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
    }
}
