namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tees", "GenderId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Tees", "GenderId");
            AddForeignKey("dbo.Tees", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tees", "GenderId", "dbo.Genders");
            DropIndex("dbo.Tees", new[] { "GenderId" });
            DropColumn("dbo.Tees", "GenderId");
            DropTable("dbo.Genders");
        }
    }
}
