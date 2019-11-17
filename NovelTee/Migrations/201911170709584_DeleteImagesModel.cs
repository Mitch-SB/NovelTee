namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteImagesModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Images");
        }
        
        public override void Down()
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
            
        }
    }
}
