namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateColor : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Colors (Id, Name) VALUES(1, 'Red')");
            Sql("INSERT INTO Colors (Id, Name) VALUES(2, 'Green')");
            Sql("INSERT INTO Colors (Id, Name) VALUES(3, 'Blue')");
            Sql("INSERT INTO Colors (Id, Name) VALUES(4, 'Yellow')");
            Sql("INSERT INTO Colors (Id, Name) VALUES(5, 'Pink')");

        }

        public override void Down()
        {
        }
    }
}
