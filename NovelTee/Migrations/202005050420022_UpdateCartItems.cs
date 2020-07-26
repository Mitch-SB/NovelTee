namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCartItems : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CartItems");
            DropColumn("dbo.CartItems", "Id");
            AddColumn("dbo.CartItems", "RecordId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CartItems", "CartId", c => c.String());
            AddPrimaryKey("dbo.CartItems", "RecordId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CartItems");
            DropColumn("dbo.CartItems", "CartId");
            DropColumn("dbo.CartItems", "RecordId");
            AddPrimaryKey("dbo.CartItems", "Id");
        }
    }
}
