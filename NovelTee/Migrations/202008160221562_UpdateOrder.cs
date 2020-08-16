namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
            AddColumn("dbo.Orders", "_context_RequireUniqueEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "_shoppingCart_ShoppingCartId", c => c.String(maxLength: 128));
            AlterColumn("dbo.CartItems", "ShoppingCartId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CartItems", "ShoppingCartId");
            CreateIndex("dbo.Orders", "_shoppingCart_ShoppingCartId");
            AddForeignKey("dbo.CartItems", "ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
            AddForeignKey("dbo.Orders", "_shoppingCart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "_shoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.CartItems", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.Orders", new[] { "_shoppingCart_ShoppingCartId" });
            DropIndex("dbo.CartItems", new[] { "ShoppingCartId" });
            AlterColumn("dbo.CartItems", "ShoppingCartId", c => c.String());
            DropColumn("dbo.Orders", "_shoppingCart_ShoppingCartId");
            DropColumn("dbo.Orders", "_context_RequireUniqueEmail");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
