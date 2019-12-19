namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserToShoppingCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCarts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "ApplicationUser_Id");
            AddForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ShoppingCarts", "ApplicationUser_Id");
            DropColumn("dbo.ShoppingCarts", "ApplicationUserId");
        }
    }
}
