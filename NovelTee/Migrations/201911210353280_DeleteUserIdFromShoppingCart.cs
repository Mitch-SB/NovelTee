namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserIdFromShoppingCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "UserId", "dbo.Users");
            DropIndex("dbo.ShoppingCarts", new[] { "UserId" });
            DropColumn("dbo.ShoppingCarts", "UserId");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ShoppingCarts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "UserId");
            AddForeignKey("dbo.ShoppingCarts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
