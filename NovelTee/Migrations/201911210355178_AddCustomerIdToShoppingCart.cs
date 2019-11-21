namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerIdToShoppingCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "CustomerId");
            AddForeignKey("dbo.ShoppingCarts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "CustomerId" });
            DropColumn("dbo.ShoppingCarts", "CustomerId");
        }
    }
}
