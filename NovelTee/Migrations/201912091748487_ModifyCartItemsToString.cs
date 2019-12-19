namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCartItemsToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.CartItems", new[] { "ShoppingCartId" });
            AddColumn("dbo.CartItems", "ShoppingCart_Id", c => c.Int());
            AlterColumn("dbo.CartItems", "ShoppingCartId", c => c.String());
            CreateIndex("dbo.CartItems", "ShoppingCart_Id");
            AddForeignKey("dbo.CartItems", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.CartItems", new[] { "ShoppingCart_Id" });
            AlterColumn("dbo.CartItems", "ShoppingCartId", c => c.Int(nullable: false));
            DropColumn("dbo.CartItems", "ShoppingCart_Id");
            CreateIndex("dbo.CartItems", "ShoppingCartId");
            AddForeignKey("dbo.CartItems", "ShoppingCartId", "dbo.ShoppingCarts", "Id", cascadeDelete: true);
        }
    }
}
