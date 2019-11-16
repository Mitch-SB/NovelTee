namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImgPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tees", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tees", "ImageId");
            AddForeignKey("dbo.Tees", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tees", "ImageId", "dbo.Images");
            DropIndex("dbo.Tees", new[] { "ImageId" });
            DropColumn("dbo.Tees", "ImageId");
            DropTable("dbo.Images");
        }
    }
}
