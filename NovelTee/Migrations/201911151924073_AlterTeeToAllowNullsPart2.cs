namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTeeToAllowNullsPart2 : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Tees ALTER COLUMN ColorId tinyint NULL");
            Sql("ALTER TABLE Tees ALTER COLUMN SizeId tinyint NULL");
            Sql("ALTER TABLE Tees ALTER COLUMN GenderId tinyint NULL");
            Sql("ALTER TABLE Tees ALTER COLUMN ImageId int NULL");
        }
        
        public override void Down()
        {
        }
    }
}
