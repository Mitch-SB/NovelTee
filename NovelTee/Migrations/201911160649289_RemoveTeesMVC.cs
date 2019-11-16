namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTeesMVC : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tees", "ImageId", "dbo.Images");
            DropIndex("dbo.Tees", new[] { "ImageId" });
            DropTable("dbo.Tees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Tees", "ImageId");
            AddForeignKey("dbo.Tees", "ImageId", "dbo.Images", "Id");
        }
    }
}
