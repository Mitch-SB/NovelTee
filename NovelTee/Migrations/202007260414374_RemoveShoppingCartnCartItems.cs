namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveShoppingCartnCartItems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartItems", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropForeignKey("dbo.CartItems", "TeeVariantId", "dbo.TeeVariants");
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.CartItems", new[] { "TeeVariantId" });
            DropIndex("dbo.CartItems", new[] { "ShoppingCart_Id" });
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUserId" });
            DropTable("dbo.CartItems");
            DropTable("dbo.ShoppingCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        TeeVariantId = c.Int(nullable: false),
                        ShoppingCartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        ShoppingCart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RecordId);
            
            CreateIndex("dbo.ShoppingCarts", "ApplicationUserId");
            CreateIndex("dbo.CartItems", "ShoppingCart_Id");
            CreateIndex("dbo.CartItems", "TeeVariantId");
            CreateIndex("dbo.CartItems", "ProductId");
            AddForeignKey("dbo.CartItems", "TeeVariantId", "dbo.TeeVariants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CartItems", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
            AddForeignKey("dbo.ShoppingCarts", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CartItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
