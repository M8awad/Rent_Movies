namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'57ee908a-cae8-44a2-a4f4-59bdc7e6606c', N'guest@vidly.com', 0, N'AFdSCbNp/U8OKmLgpqNM5yLcgPqFy+WXYforOmfrym+hcCxzyKzWC5I1OQn2bG0gnw==', N'fa37ccc8-6155-42cd-a930-3c6ed881c809', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bc191ee2-cf8e-4bf4-927f-db230b2f4668', N'admin@vidly.com', 0, N'AD1TWfFIxUHh/X23EdR6BH2Pu2tgQXYfhGkr1Pi/9x4Wo8lOFiWGd0I/7sRXWoUbxA==', N'bc9751ad-f9df-447d-9552-d734e45d73e1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'980f997f-a0fc-411e-aba2-159147a8507e', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bc191ee2-cf8e-4bf4-927f-db230b2f4668', N'980f997f-a0fc-411e-aba2-159147a8507e')

");
        }
        
        public override void Down()
        {
        }
    }
}
