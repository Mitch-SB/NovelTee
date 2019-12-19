namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserToShoppingCart3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "ApplicationUserId");
            AddForeignKey("dbo.ShoppingCarts", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUserId" });
            DropColumn("dbo.ShoppingCarts", "ApplicationUserId");
        }
    }
}
