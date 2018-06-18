namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {//Root1! - pass
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a5df975d-99b4-4eb9-af91-4de185624772', N'admin@vidly.com', 0, N'AHnazPSRG+enk+ztOQuAMbvmJPO+YFqdww8hkdMQ5ifrTPsvRvYjZQlIzLb4DDIKUQ==', N'ccd6c37b-33d3-41d9-9463-6d08abf85d5b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e8648758-0f56-4a77-89ab-a605fd8fbbf1', N'guest@vidly.com', 0, N'ACDwIm8efWDQVmeSl6EJzriD6arT2e/4XtwrYIkhkD2pIhGoQoIglHqHucl7GH7y+g==', N'57d9ec3f-5e82-4437-a9dc-23bc7b7d8746', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'614fec08-1ca8-471f-9a29-75b96592eb13', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a5df975d-99b4-4eb9-af91-4de185624772', N'614fec08-1ca8-471f-9a29-75b96592eb13')


");
        }
        
        public override void Down()
        {
        }
    }
}
