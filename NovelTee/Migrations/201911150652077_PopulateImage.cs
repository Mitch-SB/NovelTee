namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateImage : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Images (Name, ImgPath) VALUES ('Default', '~/Content/Images/NovelTee.png')");
            
        }
        
        public override void Down()
        {
        }
    }
}
