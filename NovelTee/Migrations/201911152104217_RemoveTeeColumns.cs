namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTeeColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tees", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Tees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Tees", "SizeId", "dbo.Sizes");
            DropIndex("dbo.Tees", new[] { "ColorId" });
            DropIndex("dbo.Tees", new[] { "SizeId" });
            DropIndex("dbo.Tees", new[] { "GenderId" });
            DropColumn("dbo.Tees", "ColorId");
            DropColumn("dbo.Tees", "SizeId");
            DropColumn("dbo.Tees", "GenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tees", "GenderId", c => c.Byte());
            AddColumn("dbo.Tees", "SizeId", c => c.Byte());
            AddColumn("dbo.Tees", "ColorId", c => c.Byte());
            CreateIndex("dbo.Tees", "GenderId");
            CreateIndex("dbo.Tees", "SizeId");
            CreateIndex("dbo.Tees", "ColorId");
            AddForeignKey("dbo.Tees", "SizeId", "dbo.Sizes", "Id");
            AddForeignKey("dbo.Tees", "GenderId", "dbo.Genders", "Id");
            AddForeignKey("dbo.Tees", "ColorId", "dbo.Colors", "Id");
        }
    }
}
