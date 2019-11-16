namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tees", "ColorId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Tees", "ColorId");
            AddForeignKey("dbo.Tees", "ColorId", "dbo.Colors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tees", "ColorId", "dbo.Colors");
            DropIndex("dbo.Tees", new[] { "ColorId" });
            DropColumn("dbo.Tees", "ColorId");
            DropTable("dbo.Colors");
        }
    }
}
