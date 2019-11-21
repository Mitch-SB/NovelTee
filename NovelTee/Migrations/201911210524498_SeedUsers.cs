namespace NovelTee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'497c74e3-78d8-415b-a590-38006e849e41', N'guest@NovelTee.com', 0, N'AHChV2iyxgGO47StWVZzzMR45ZzN5YvQ2+BxajVAqAM+0Wi9yOJhRsoMvkHMvEv/Sw==', N'3cc8e956-6f23-48a5-a3a5-9a7772118440', NULL, 0, 0, NULL, 1, 0, N'guest@NovelTee.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'baa074dc-3472-4bf8-9274-06f1c5cecbdd', N'admin@noveltee.com', 0, N'AGK9Za2SREVxD886PUF67Jw0F+iksyasv4Bo/vK7y+TmwgggaeWEXWQhbSXX0HQwrQ==', N'dc1cff69-ddd6-43f8-9a5e-cf1c60b7f7bd', NULL, 0, 0, NULL, 1, 0, N'admin@noveltee.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df54efc9-91b2-4706-ad78-07720f42b2eb', N'CanManageProducts')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'baa074dc-3472-4bf8-9274-06f1c5cecbdd', N'df54efc9-91b2-4706-ad78-07720f42b2eb')

");
        }
        
        public override void Down()
        {
        }
    }
}
