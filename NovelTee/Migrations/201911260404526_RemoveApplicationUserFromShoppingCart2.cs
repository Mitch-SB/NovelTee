namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveApplicationUserFromShoppingCart2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ShoppingCarts", "ApplicationUserId");
            DropColumn("dbo.ShoppingCarts", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.ShoppingCarts", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "ApplicationUser_Id");
            AddForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
