namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTeeToAllowNulls : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tees", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Tees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Tees", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Tees", "SizeId", "dbo.Sizes");
            DropIndex("dbo.Tees", new[] { "ColorId" });
            DropIndex("dbo.Tees", new[] { "SizeId" });
            DropIndex("dbo.Tees", new[] { "GenderId" });
            DropIndex("dbo.Tees", new[] { "ImageId" });
            AlterColumn("dbo.Tees", "ColorId", c => c.Byte());
            AlterColumn("dbo.Tees", "SizeId", c => c.Byte());
            AlterColumn("dbo.Tees", "GenderId", c => c.Byte());
            AlterColumn("dbo.Tees", "ImageId", c => c.Int());
            CreateIndex("dbo.Tees", "ColorId");
            CreateIndex("dbo.Tees", "SizeId");
            CreateIndex("dbo.Tees", "GenderId");
            CreateIndex("dbo.Tees", "ImageId");
            AddForeignKey("dbo.Tees", "ColorId", "dbo.Colors", "Id");
            AddForeignKey("dbo.Tees", "GenderId", "dbo.Genders", "Id");
            AddForeignKey("dbo.Tees", "ImageId", "dbo.Images", "Id");
            AddForeignKey("dbo.Tees", "SizeId", "dbo.Sizes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tees", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.Tees", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Tees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Tees", "ColorId", "dbo.Colors");
            DropIndex("dbo.Tees", new[] { "ImageId" });
            DropIndex("dbo.Tees", new[] { "GenderId" });
            DropIndex("dbo.Tees", new[] { "SizeId" });
            DropIndex("dbo.Tees", new[] { "ColorId" });
            AlterColumn("dbo.Tees", "ImageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tees", "GenderId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tees", "SizeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tees", "ColorId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Tees", "ImageId");
            CreateIndex("dbo.Tees", "GenderId");
            CreateIndex("dbo.Tees", "SizeId");
            CreateIndex("dbo.Tees", "ColorId");
            AddForeignKey("dbo.Tees", "SizeId", "dbo.Sizes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tees", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tees", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tees", "ColorId", "dbo.Colors", "Id", cascadeDelete: true);
        }
    }
}
