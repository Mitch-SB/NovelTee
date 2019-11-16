namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Cat_Name) VALUES (1, 'Tees')," +
                "(2, 'Tank Tees')," +
                "(3, 'Hood Tees')");
        }
        
        public override void Down()
        {
        }
    }
}
