namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeeVariant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeeVariants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorId = c.Byte(nullable: false),
                        SizeId = c.Byte(nullable: false),
                        GenderId = c.Byte(nullable: false),
                        Quantity = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ColorId)
                .Index(t => t.SizeId)
                .Index(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeeVariants", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.TeeVariants", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.TeeVariants", "ColorId", "dbo.Colors");
            DropIndex("dbo.TeeVariants", new[] { "GenderId" });
            DropIndex("dbo.TeeVariants", new[] { "SizeId" });
            DropIndex("dbo.TeeVariants", new[] { "ColorId" });
            DropTable("dbo.TeeVariants");
        }
    }
}
