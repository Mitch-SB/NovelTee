namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddCartItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        ShoppingCartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        TeeVariantId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TeeVariants", t => t.TeeVariantId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TeeVariantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "TeeVariantId", "dbo.TeeVariants");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "TeeVariantId" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropTable("dbo.CartItems");
        }
    }
}
