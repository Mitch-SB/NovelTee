namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSize : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sizes (Id, Name) VALUES (1, 'S')");
            Sql("INSERT INTO Sizes (Id, Name) VALUES (2, 'M')");
            Sql("INSERT INTO Sizes (Id, Name) VALUES (3, 'L')");
            Sql("INSERT INTO Sizes (Id, Name) VALUES (4, 'XL')");
        }
        
        public override void Down()
        {
        }
    }
}
