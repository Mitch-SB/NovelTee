namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToTeeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tees", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tees", "Name", c => c.String());
        }
    }
}
