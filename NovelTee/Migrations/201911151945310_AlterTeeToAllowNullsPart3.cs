namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTeeToAllowNullsPart3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tees", "ColorId", c => c.Byte(nullable: true));
            AlterColumn("dbo.Tees", "SizeId", c => c.Byte(nullable: true));
            AlterColumn("dbo.Tees", "GenderId", c => c.Byte(nullable: true));
            AlterColumn("dbo.Tees", "ImageId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
