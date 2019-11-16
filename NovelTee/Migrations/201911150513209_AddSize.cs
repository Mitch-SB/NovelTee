namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tees", "SizeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Tees", "SizeId");
            AddForeignKey("dbo.Tees", "SizeId", "dbo.Sizes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tees", "SizeId", "dbo.Sizes");
            DropIndex("dbo.Tees", new[] { "SizeId" });
            DropColumn("dbo.Tees", "SizeId");
            DropTable("dbo.Sizes");
        }
    }
}
