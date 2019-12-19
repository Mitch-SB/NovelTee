namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShoppingCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "CustomerId" });
            AddColumn("dbo.ShoppingCarts", "AppUserId", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCarts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "ApplicationUser_Id");
            AddForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.ShoppingCarts", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ShoppingCarts", "ApplicationUser_Id");
            DropColumn("dbo.ShoppingCarts", "AppUserId");
            CreateIndex("dbo.ShoppingCarts", "CustomerId");
            AddForeignKey("dbo.ShoppingCarts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
